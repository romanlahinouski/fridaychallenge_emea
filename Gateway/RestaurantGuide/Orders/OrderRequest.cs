using RestaurantGuide.Application.Orders.Commands;
using System.Collections.Generic;

namespace RestaurantGuide.Orders.Administration
{
    public class OrderRequest
    {
        public OrderItemDto [] Dishes { get; set; }

        public int GuestId { get; set; }

        public string GuestEmail { get; set; }

    }
}