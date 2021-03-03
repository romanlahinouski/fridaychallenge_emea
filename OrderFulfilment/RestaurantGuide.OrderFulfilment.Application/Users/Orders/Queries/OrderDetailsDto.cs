using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using System.Collections.Generic;

namespace RestaurantGuide.OrderFulfilment.Application.Orders.Queries
{
    public class OrderDetailsDto
    {
        public decimal OrderAmount { get; set; }

        public IReadOnlyCollection<OrderItem> OrderItems { get; set; }

        public int OrderId { get; set; }

        public OrderDetailsDto(decimal orderAmount, IReadOnlyCollection<OrderItem> orderItems, int orderId)
        {
            OrderAmount = orderAmount;
            OrderItems = orderItems;
            OrderId = orderId;
        }

    }
}
