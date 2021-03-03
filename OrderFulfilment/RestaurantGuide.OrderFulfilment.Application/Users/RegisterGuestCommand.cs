using MediatR;
using System;
namespace RestaurantGuide.OrderFulfilment.Application.Restaurants
{
    public class RegisterGuestCommand : IRequest
    {       
        public RegisterGuestCommand(string email,
            string phoneNumber,
            int restaurantId,
            string firstName = default,
            string lastName = default)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            RestaurantId = restaurantId;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; }
        public string PhoneNumber { get; }
        public int RestaurantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
