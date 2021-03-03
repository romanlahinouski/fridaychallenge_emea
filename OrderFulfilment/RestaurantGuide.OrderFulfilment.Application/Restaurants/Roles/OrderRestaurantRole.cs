using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using System;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
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
