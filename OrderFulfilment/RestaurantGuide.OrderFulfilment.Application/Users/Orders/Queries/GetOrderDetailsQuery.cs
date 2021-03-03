using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Orders.Queries
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsDto>
    {
        public int OrderId { get; set; }

        public GetOrderDetailsQuery(int orderId)
        {
            OrderId = orderId;
        }

    }
}
