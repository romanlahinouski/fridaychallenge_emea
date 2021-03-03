using RestaurantGuide.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class UserNotRegisterForAVisitException : Exception
    {
        public int UserId { get; set; }

    
        public UserNotRegisterForAVisitException(string message,int userId) : base(message)
        {
            UserId = userId;
        }
      

    }
}
