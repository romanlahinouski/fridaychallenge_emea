using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants
{
    public class RegisterGuestCommandHandler : AsyncRequestHandler<RegisterGuestCommand>
    {
        private readonly IGuestRegistrationContext GuestRegistrationContext;

        public RegisterGuestCommandHandler(IGuestRegistrationContext GuestRegistrationContext)
        {
            this.GuestRegistrationContext = GuestRegistrationContext;
        }

        protected override async Task Handle(RegisterGuestCommand request, CancellationToken cancellationToken)
        {
           await GuestRegistrationContext.RegisterGuest(
                request);            
        }
    }
}
