using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Domain.Guests;

namespace RestaurantGuide.Application.Guests.Commands
{
    public class CreateGuestCommandHandler : AsyncRequestHandler<CreateGuestCommand>
    {
        private readonly IGuestRepository userRepository;
        private readonly ILogger<CreateGuestCommandHandler> logger;

        public CreateGuestCommandHandler(IGuestRepository userRepository, ILogger<CreateGuestCommandHandler> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        protected override  async Task Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var user = Guest.CreateGuest(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

            await userRepository.Add(user);

            logger.LogInformation($"Guest with name : {request.FirstName} {request.LastName} was created");
        }
    }
}
