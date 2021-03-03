using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
{
    public class RegistrationRestaurantRole : IRegistrationRestaurantRole
    {
        public void RegisterUser(User user, Restaurant restaurant)
        {
            if (!HasCapacity(restaurant))
                throw new Exception();

            restaurant.RegisterUser(user);
        }


        private bool HasCapacity(Restaurant restaurant)
        {
            if (restaurant.GetCurrentNumberOfUsers() >= restaurant.GetMaxNumberOfGuests())
                return false;

            return true;
        }
    }
}
