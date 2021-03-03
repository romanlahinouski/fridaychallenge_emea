using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Users.Orders;
using RestaurantGuide.OrderFulfilment.Users.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Restaurants.Roles
{
    class OrderRestaurantRole : IOrderRestaurantRole
    {
   
        public OrderRestaurantRole()
        {
       
        }
        /// <summary>
        /// Place to add additional order acceptence related logic
        /// </summary>
        /// <param name="dishesDtos"></param>
        public void AcceptOrder(Order order)
        {
            throw new NotImplementedException();         
        }
    }
}
