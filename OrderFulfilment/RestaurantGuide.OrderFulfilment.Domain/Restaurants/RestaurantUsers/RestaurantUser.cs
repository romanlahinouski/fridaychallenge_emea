using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Domain.Restaurants.RestaurantGuests
{
   public class RestaurantGuest
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int GuestId { get; set; }

    }
}
