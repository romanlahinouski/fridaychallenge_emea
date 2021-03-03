using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.OrderFulfilment.Domain.Users;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
{
    public interface IRegistrationRestaurantRole : IBaseRole<Restaurant>
    {
        public void RegisterUser(User user, Restaurant restaurant);
    }
}
