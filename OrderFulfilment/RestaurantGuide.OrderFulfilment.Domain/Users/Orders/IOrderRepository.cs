using System;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Domain.Guests.Orders
{
    public interface IOrderRepository
    {
        public Order GetUnpaidOrders(int GuestId);

        public void PutOrder(Order order);

        public Task<Order> GetOrderById(int orderId);
    }
}
