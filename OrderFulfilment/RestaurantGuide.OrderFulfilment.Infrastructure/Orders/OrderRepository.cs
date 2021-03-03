using Microsoft.EntityFrameworkCore;
using RestaurantGuide.OrderFulfilment.Domain.Orders;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using RestaurantGuide.OrderFulfilment.Infrastructure.Guests;
using System;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderFulfilmentDbContext orderFulfilmentDbContext;
     
        public OrderRepository(OrderFulfilmentDbContext orderFulfilmentDbContext)
        {
            this.orderFulfilmentDbContext = orderFulfilmentDbContext;          
        }
        
        public async Task<Order> GetOrderById(int orderId)
        {
                        
            return await orderFulfilmentDbContext.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Dish)
                .FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public Order GetUnpaidOrders(int GuestId)
        {
            throw new NotImplementedException();
        }

        public void PutOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
