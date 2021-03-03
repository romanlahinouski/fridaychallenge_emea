using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public interface IPutOrderContext
    {
        Task PutOrder(List<DishItemDto> dishesDtos, int userId);
    }
}