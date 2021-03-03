using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class PutOrderCommandHandler : AsyncRequestHandler<PutOrderCommand>
    {
        private readonly IPutOrderContext putOrderContext;

        public PutOrderCommandHandler(IPutOrderContext putOrderContext)
        {
            this.putOrderContext = putOrderContext;
        }

        protected override Task Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {
            putOrderContext.PutOrder(request.Products, 
                request.GuestId);

            return Task.CompletedTask;
        }
    }
}
