using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
{
    public class RegistrationRestaurantRole : IRegistrationRestaurantRole
    {
        public void RegisterGuest(Guest Guest, Restaurant restaurant)
        {
            if (!HasCapacity(restaurant))
                throw new Exception();

            restaurant.RegisterGuest(Guest);
        }


        private bool HasCapacity(Restaurant restaurant)
        {
            if (restaurant.GetCurrentNumberOfGuests() >= restaurant.GetMaxNumberOfGuests())
                return false;

            return true;
        }
    }
}
