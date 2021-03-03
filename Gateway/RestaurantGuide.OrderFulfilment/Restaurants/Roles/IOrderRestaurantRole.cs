using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Users.Orders;
using RestaurantGuide.OrderFulfilment.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Restaurants.Roles
{
   public interface IOrderRestaurantRole : IBaseRole<Restaurant>
    {
        public void AcceptOrder(Order order);
    }
}
