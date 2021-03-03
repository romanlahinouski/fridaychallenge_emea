using RestaurantGuide.API.Guests.Protos;
using RestaurantGuide.Application.Guests;
using RestaurantGuide.Application.Guests.Commands;
using System.Threading.Tasks;


namespace RestaurantGuide.Guests
{
    public class GuestGrpcService : IGuestGrpcService
    {
        private readonly GuestRegistrationServiceProto.GuestRegistrationServiceProtoClient userRegistrationClient;

        public GuestGrpcService(GuestRegistrationServiceProto.GuestRegistrationServiceProtoClient userRegistrationClient)
        {
            this.userRegistrationClient = userRegistrationClient;
        }
        
        public async Task RegisterForAVisitAsync(RegisterGuestCommand registerGuestCommand)
        {        
          await userRegistrationClient.RegisterGuestAsync(
                new GuestRegistrationRequest {  
                GuestEmail = registerGuestCommand.GuestEmail,
                GuestPhoneNumber = registerGuestCommand.GuestPhoneNumber,
                GuestFirstName = registerGuestCommand.GuestFirstName,
                GuestLastName = registerGuestCommand.GuestLastName,
                RestaurantId = registerGuestCommand.RestaurantId
                });         
        }
    }
}
