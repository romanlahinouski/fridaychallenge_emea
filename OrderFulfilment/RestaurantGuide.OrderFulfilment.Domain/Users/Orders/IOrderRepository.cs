using System;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Domain.Users.Orders
{
    public interface IOrderRepository
    {
        public Order GetUnpaidOrders(int userId);

        public void PutOrder(Order order);

        public Task<Order> GetOrderById(int orderId);
    }
}
