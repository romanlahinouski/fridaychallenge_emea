using RestaurantGuide.OrderFulfilment.Application.Guests.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
    public interface IPutOrderContext
    {
        Task PutOrder(List<OrderItemDto> dishesDtos, int GuestId);
    }
}