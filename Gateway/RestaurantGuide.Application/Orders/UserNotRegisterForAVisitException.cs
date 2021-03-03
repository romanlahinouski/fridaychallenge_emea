using RestaurantGuide.Domain.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Application.Orders
{
    public class GuestNotRegisterForAVisitException : Exception
    {
        public int GuestId { get; set; }

    
        public GuestNotRegisterForAVisitException(string message,int userId) : base(message)
        {
            GuestId = userId;
        }
      

    }
}
