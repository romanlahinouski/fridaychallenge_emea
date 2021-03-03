using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants
{
    public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRegistrationContext userRegistrationContext;

        public RegisterUserCommandHandler(IUserRegistrationContext userRegistrationContext)
        {
            this.userRegistrationContext = userRegistrationContext;
        }

        protected override async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
           await userRegistrationContext.RegisterUser(
                request);            
        }
    }
}
