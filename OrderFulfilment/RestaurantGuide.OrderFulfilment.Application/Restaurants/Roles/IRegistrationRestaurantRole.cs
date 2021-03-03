using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.OrderFulfilment.Domain.Guests;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
{
    public interface IRegistrationRestaurantRole : IBaseRole<Restaurant>
    {
        public void RegisterGuest(Guest Guest, Restaurant restaurant);
    }
}
