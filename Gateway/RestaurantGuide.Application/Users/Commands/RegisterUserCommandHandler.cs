using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace RestaurantGuide.Application.Guests.Commands
{
    public class RegisterGuestCommandHandler : AsyncRequestHandler<RegisterGuestCommand>
    {
        private readonly IGuestGrpcService userGrpcService;
        private readonly ILogger<RegisterGuestCommandHandler> logger;

        public RegisterGuestCommandHandler(IGuestGrpcService userGrpcService, ILogger<RegisterGuestCommandHandler> logger)
        {
            this.userGrpcService = userGrpcService;
            this.logger = logger;
        }
        
        protected override async Task Handle(RegisterGuestCommand request, CancellationToken cancellationToken)
        {
            await userGrpcService.RegisterForAVisitAsync(request);

            logger.LogInformation($"Guest with name : {request.GuestFirstName} {request.GuestLastName} was registered for a visit");
        }
    }
}
