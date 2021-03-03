using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Users.Roles.OrderingGuestRole
{
    public interface IOrderingGuestRole : IBaseRole<User>
    {
        public void MakeOrder(Order order,User user);
    }
}
