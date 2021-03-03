using MediatR;
using RestaurantGuide.OrderFulfilment.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries
{
    public class GetDishesQuery : IRequest<IReadOnlyCollection<DishDto>>
    {
    }
}
