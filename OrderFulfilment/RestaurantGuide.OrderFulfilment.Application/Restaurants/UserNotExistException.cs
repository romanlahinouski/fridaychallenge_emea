using System;
namespace RestaurantGuide_Administration.Application.Restaurants.Roles.RegistrationRestaurants
{
    public class GuestNotExistException : Exception
    {
        public GuestNotExistException(string message)
            : base(message)
        {

        }
    }
}
