using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantGuide.Application.Orders;
using RestaurantGuide.Application.Orders.Commands;
using RestaurantGuide.Application.Orders.Queries;
using RestaurantGuide.Infrastructure.Orders.Protos;

namespace RestaurantGuide.Infrastructure.Orders
{
    public class OrderFulfilmentGrpcService : IOrderFulfilmentService
    {
        private readonly OrderFulfilmentServiceProto.OrderFulfilmentServiceProtoClient orderFulfilmentService;
        private readonly IMapper mapper;

        public OrderFulfilmentGrpcService(OrderFulfilmentServiceProto.OrderFulfilmentServiceProtoClient orderFulfilmentService,
            IMapper mapper
            )
        {
            this.orderFulfilmentService = orderFulfilmentService;
            this.mapper = mapper;
        }

        public async Task<List<Domain.Restaurants.Dishes.Dish>> GetDishes()
        {
         var response =  await orderFulfilmentService.GetAllRestaurantDishesAsync(new Google.Protobuf.WellKnownTypes.Empty());

         var protoDishes = response.Dishes.ToList();

           var dishes =  mapper.Map<List<Domain.Restaurants.Dishes.Dish>>(protoDishes);

            return dishes;
        }

        public  async Task<Application.Orders.Queries.OrderDetailsDto> GetOrderDetailsById(int orderId)
        {
           var getOrderDetailsRequest = new GetOrderDetailsRequest() { OrderId = orderId } ;

           var orderDetailsResponseProto = await orderFulfilmentService.GetOrderDetailsAsync(getOrderDetailsRequest);

           var orderItems = mapper.Map<IReadOnlyCollection<Application.Orders.Commands.OrderItemDto>>
                (orderDetailsResponseProto.OrderItems.AsEnumerable());

            var orderDetailsDto = new Application.Orders.Queries.OrderDetailsDto(orderDetailsResponseProto.Amount, orderItems, orderDetailsResponseProto.OrderId); 

            return orderDetailsDto;
        }

        public async Task PutOrder(List<Application.Orders.Commands.OrderItemDto> products, int userId)
        {
            PutOrderRequest putOrderRequest = new PutOrderRequest();

            var dishes = mapper.Map<List<Protos.OrderItemDto>>(products);

            putOrderRequest.OrderItems.AddRange(dishes);

            putOrderRequest.GuestId = userId;
            
            await orderFulfilmentService.PutOrderAsync(putOrderRequest);           
        }
    }
}                                        
