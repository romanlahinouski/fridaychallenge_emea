using MediatR;
using RestaurantGuide.OrderFulfilment.Domain.Orders;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Application.Orders.Queries
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        
        
        public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderById(request.OrderId);

            var orderAmount = order.GetOrderAmount();

            var orderDetails = 
                new OrderDetailsDto(orderAmount, order.OrderItems, order.OrderId);

            return orderDetails;
        }
    }
}
