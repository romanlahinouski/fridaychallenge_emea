using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Application.Orders.Commands
{
    public class PutOrderCommand : IRequest
    {
        public List<OrderItemDto> Products { get; set; }

        public int GuestId { get; set; }



    }
}
