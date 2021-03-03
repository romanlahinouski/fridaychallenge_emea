using RestaurantGuide.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using RestaurantGuide.OrderFulfilment.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Guests.Roles.OrderingGuestRole
{
    public class OrderingGuestRole : IOrderingGuestRole
    {

        public OrderingGuestRole()
        {

        }


        private void CheckIfGuestRegistered(Guest Guest)
        {

        }

        public void MakeOrder(Order order, Guest Guest)
        {
            if (Guest == null || order == null)
                throw new ArgumentNullException();
            
            if (!Guest.IsRegisteredForVisit())
                throw new GuestNotRegisterForAVisitException("Guest not registerd for a visit",Guest.GuestId);

            Guest.MakeOrder(order);
        }
    }
}
