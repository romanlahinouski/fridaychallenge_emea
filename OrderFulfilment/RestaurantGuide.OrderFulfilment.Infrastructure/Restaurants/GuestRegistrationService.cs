using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

using MediatR;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;
using RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Protos;

namespace RestaurantGuide.Infrastructure.Restaurants
{
    public class UserRegistrationService : UserRegistrationServiceProto.UserRegistrationServiceProtoBase
    {
        private readonly IMediator mediator;

        public UserRegistrationService(IMediator mediator)

        {
            this.mediator = mediator;
        }


        public override async Task<Empty> RegisterUser(UserRegistrationRequest request, ServerCallContext context)
        {
            await mediator.Send(new RegisterUserCommand(
             request.UserEmail,
             request.UserPhoneNumber,
             request.RestaurantId,
             request.UserFirstName,
             request.UserLastName
             ));

            return new Empty();
        }
    }
}