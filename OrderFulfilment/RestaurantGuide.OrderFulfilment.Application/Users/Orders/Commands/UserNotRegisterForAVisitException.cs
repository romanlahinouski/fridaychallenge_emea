using RestaurantGuide.Domain.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
    public class GuestNotRegisterForAVisitException : Exception
    {
        public int GuestId { get; set; }

    
        public GuestNotRegisterForAVisitException(string message,int GuestId) : base(message)
        {
            GuestId = GuestId;
        }
      

    }
}
