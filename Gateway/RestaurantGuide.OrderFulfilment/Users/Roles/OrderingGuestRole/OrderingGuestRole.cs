using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Users.Orders;
using RestaurantGuide.OrderFulfilment.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Roles.OrderingGuestRole
{
    public class OrderingGuestRole : IOrderingGuestRole
    {

        public OrderingGuestRole()
        {

        }


        private void CheckIfUserRegistered(User user)
        {

        }

        public void MakeOrder(Order order, User user)
        {
            if (user == null || order == null)
                throw new ArgumentNullException();
            
            if (!user.IsRegisteredForVisit())
                throw new UserNotRegisterForAVisitException("User not registerd for a visit",user.Id);

            user.MakeOrder(order);
        }
    }
}
