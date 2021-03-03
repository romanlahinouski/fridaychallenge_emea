using estaurantGuide.Application.Orders.Queries;
using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Application.Orders.Queries
{
    public class GetDishesQuery : IRequest<IReadOnlyCollection<Dish>>
    {
    }
}
