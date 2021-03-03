using System;
using System.ComponentModel;

namespace RestaurantGuide.Guests
{

    [TypeConverter(typeof(DateTimeConverter))]
    public class CreateGuestRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }           
    }
}