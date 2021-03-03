using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles
{
    public interface IOrderRestaurantRole : IBaseRole<Restaurant>
    {
        public void AcceptOrder(Order order);
    }
}
