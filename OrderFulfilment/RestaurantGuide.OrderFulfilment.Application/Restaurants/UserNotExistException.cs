using System;
namespace RestaurantGuide_Administration.Application.Restaurants.Roles.RegistrationRestaurants
{
    public class UserNotExistException : Exception
    {
        public UserNotExistException(string message)
            : base(message)
        {

        }
    }
}
