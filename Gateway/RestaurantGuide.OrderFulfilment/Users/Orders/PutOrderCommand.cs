using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
   public class PutOrderCommand : IRequest
    {
        public List<DishItemDto> Products { get; set; }

        public int GuestId { get; set; }

    }
}
