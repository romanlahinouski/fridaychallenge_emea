using System;
using MediatR;

namespace RestaurantGuide.Application.Guests.Commands
{
    public class CreateGuestCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; }
        public DateTime DateOfBirth { get; set; }

        public CreateGuestCommand(string phoneNumber,
            string firstName,
            string lastName,
            string email,
            DateTime dateofBirth = default)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateofBirth = dateofBirth;
        }
    }
}
