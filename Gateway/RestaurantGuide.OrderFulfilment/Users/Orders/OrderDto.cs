using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class OrderDto
    {
        public List<DishItemDto> Dishes { get; set; }
        public int GuestId { get; set; }
    }
}
