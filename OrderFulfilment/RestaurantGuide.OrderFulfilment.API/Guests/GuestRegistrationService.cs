using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using RestaurantGuide.OrderFulfilment.API.Restaurants.Protos;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;


namespace RestaurantGuide.Infrastructure.Restaurants
{
    public class GuestRegistrationService : GuestRegistrationServiceProto.GuestRegistrationServiceProtoBase
    {
        private readonly IMediator mediator;

        public GuestRegistrationService(IMediator mediator)

        {
            this.mediator = mediator;
        }


        public override async Task<Empty> RegisterGuest(GuestRegistrationRequest request, ServerCallContext context)
        {
            await mediator.Send(new RegisterGuestCommand(
             request.GuestEmail,
             request.GuestPhoneNumber,
             request.RestaurantId,
             request.GuestFirstName,
             request.GuestLastName
             ));

            return new Empty();
        }
    }
}