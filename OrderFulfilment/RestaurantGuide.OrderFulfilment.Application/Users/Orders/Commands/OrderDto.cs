using RestaurantGuide.OrderFulfilment.Application.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class OrderDto
    {
        public List<OrderItemDto> Dishes { get; set; }
        public int UserId { get; set; }
    }
}
