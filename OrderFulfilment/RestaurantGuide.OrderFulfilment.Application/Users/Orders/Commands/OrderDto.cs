using RestaurantGuide.OrderFulfilment.Application.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
    public class OrderDto
    {
        public List<OrderItemDto> Dishes { get; set; }
        public int GuestId { get; set; }
    }
}
