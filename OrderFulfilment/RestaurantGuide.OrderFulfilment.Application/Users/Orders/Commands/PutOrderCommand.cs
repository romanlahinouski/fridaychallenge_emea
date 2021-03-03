using MediatR;
using RestaurantGuide.OrderFulfilment.Application.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
   public class PutOrderCommand : IRequest
    {
    
        public List<OrderItemDto> DishItems { get; }
        public int GuestId { get; }

        public PutOrderCommand(List<OrderItemDto>  dishItems, int GuestId)
        {
            DishItems = dishItems;
            GuestId = GuestId;
        }

    }
}
