using System;
namespace RestaurantGuide.OrderFulfilment.Application.Users.Orders
{
    public class OrderItemDto
    {
        public int Count { get; set; }

        public int DishId { get; set; }

        public OrderItemDto()
        {
        }
    }
}
