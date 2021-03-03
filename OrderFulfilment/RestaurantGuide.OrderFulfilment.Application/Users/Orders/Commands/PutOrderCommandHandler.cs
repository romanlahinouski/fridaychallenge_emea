using MediatR;
using RestaurantGuide.OrderFulfilment.Application;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
    public class PutOrderCommandHandler : AsyncRequestHandler<PutOrderCommand>
    {
        private readonly IPutOrderContext putOrderContext;

        public PutOrderCommandHandler(IPutOrderContext putOrderContext)
        {
            this.putOrderContext = putOrderContext;
        }
        
        protected override async Task Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {
            await putOrderContext.PutOrder(request.DishItems,
              request.GuestId); 



        }
    }
}
