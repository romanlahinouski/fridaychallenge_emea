using System.Threading.Tasks;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;

namespace RestaurantGuide.OrderFulfilment.Application
{
    public interface IGuestRegistrationContext
    {
        public Task RegisterGuest(RegisterGuestCommand registerGuestCommand); 
    }
}
