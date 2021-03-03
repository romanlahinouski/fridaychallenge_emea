using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Application.Orders.Queries
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsDto>
    {
        public int OrderId { get; set; }

    }
}
