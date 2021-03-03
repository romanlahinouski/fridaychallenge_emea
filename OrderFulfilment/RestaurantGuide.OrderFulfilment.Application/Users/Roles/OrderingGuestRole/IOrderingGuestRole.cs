using RestaurantGuide.Domain.Base;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using RestaurantGuide.OrderFulfilment.Domain.Users.Orders;

namespace RestaurantGuide.OrderFulfilment.Users.Roles.OrderingUserRole
{
    public interface IOrderingUserRole : IBaseRole<User>
    {
        public void MakeOrder(Order order,User user);
    }
}
