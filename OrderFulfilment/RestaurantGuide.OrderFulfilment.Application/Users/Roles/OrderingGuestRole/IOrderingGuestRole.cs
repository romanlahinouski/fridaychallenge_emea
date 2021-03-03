using RestaurantGuide.Domain.Base;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;

namespace RestaurantGuide.OrderFulfilment.Guests.Roles.OrderingGuestRole
{
    public interface IOrderingGuestRole : IBaseRole<Guest>
    {
        public void MakeOrder(Order order,Guest Guest);
    }
}
