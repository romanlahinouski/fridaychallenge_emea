using System.Threading.Tasks;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;

namespace RestaurantGuide.OrderFulfilment.Application
{
    public interface IUserRegistrationContext
    {
        public Task RegisterUser(RegisterUserCommand registerUserCommand); 
    }
}
