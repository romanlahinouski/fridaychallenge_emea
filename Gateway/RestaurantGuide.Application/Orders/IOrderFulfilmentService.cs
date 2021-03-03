using RestaurantGuide.Application.Orders.Commands;
using RestaurantGuide.Application.Orders.Queries;
using RestaurantGuide.Domain.Restaurants.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.Application.Orders
{
   public interface IOrderFulfilmentService
    {

        Task PutOrder(List<OrderItemDto> products, int userId);

        Task<List<Dish>> GetDishes();

        Task<OrderDetailsDto> GetOrderDetailsById(int orderId);

    }
}
