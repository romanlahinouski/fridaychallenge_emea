using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using RestaurantGuide.OrderFulfilment.Application.Orders.Queries;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries;
using RestaurantGuide.OrderFulfilment.Infrastructure.Orders.Protos;
using RestaurantGuide.OrderFulfilment.Guests.Orders;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Orders
{
    public class OrderFulfimentGrpcService : OrderFulfilmentServiceProto.OrderFulfilmentServiceProtoBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OrderFulfimentGrpcService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        
        public override async Task<GetAllRestaurantDishesResponse> GetAllRestaurantDishes(Empty request, ServerCallContext context)
        {

            var dishes = await mediator.Send(new GetDishesGrpcQuery());

            var dishesMessage = mapper.Map<IEnumerable<Dish>>(dishes);
                    
            GetAllRestaurantDishesResponse getAllRestaurantDishesResponse = new GetAllRestaurantDishesResponse();

            getAllRestaurantDishesResponse.Dishes.AddRange(dishesMessage);

            return getAllRestaurantDishesResponse;

        }
         

        public override async Task<Empty> PutOrder(PutOrderRequest request, ServerCallContext context)
        {

            var dishesProto = request.OrderItems.ToList();

            var dishesDto = mapper.Map <List<Application.Guests.Orders.OrderItemDto>>(dishesProto);


            await mediator.Send(new PutOrderCommand(dishesDto, request.GuestId));

            return new Empty();
        }


        public override async Task<Orderfulfilment.Infrastructure.Orders.Protos.OrderDetailsDto> GetOrderDetails
            (GetOrderDetailsRequest request, ServerCallContext context)
        {
            var orderDetails = await mediator.Send(new GetOrderDetailsQuery(request.OrderId));

            var orderDetailsProto = new Orderfulfilment.Infrastructure.Orders.Protos.OrderDetailsDto() 
            { 
                Amount = (int) orderDetails.OrderAmount,
                OrderId = orderDetails.OrderId
            };

            IEnumerable<Protos.OrderItemDto> orderItemDtosProtos
                = mapper.Map<IEnumerable<Protos.OrderItemDto>>(orderDetails.OrderItems);

            orderDetailsProto.OrderItems.AddRange(orderItemDtosProtos);

            return orderDetailsProto;
        }

    }
}
