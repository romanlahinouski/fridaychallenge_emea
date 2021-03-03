using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Application.Guests.Commands
{
   public class RegisterGuestCommand : IRequest
    {
        public RegisterGuestCommand(
            int restaurantId,
            string userEmail, 
            string userPhoneNumber,
            string userFirstName,
            string userLastName
            )
        {
            RestaurantId = restaurantId;
            GuestEmail = userEmail;
            GuestPhoneNumber = userPhoneNumber;
            GuestFirstName = userFirstName;
            GuestLastName = userLastName;               
        }
        
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string NumberOfPlaces { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhoneNumber { get; set; }
        public int RestaurantId { get; set; }

    }
}
