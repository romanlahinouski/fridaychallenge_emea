using MediatR;
using RestaurantGuide.OrderFulfilment.Application.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
   public class PutOrderCommand : IRequest
    {
    
        public List<OrderItemDto> DishItems { get; }
        public int UserId { get; }

        public PutOrderCommand(List<OrderItemDto>  dishItems, int userId)
        {
            DishItems = dishItems;
            UserId = userId;
        }

    }
}
