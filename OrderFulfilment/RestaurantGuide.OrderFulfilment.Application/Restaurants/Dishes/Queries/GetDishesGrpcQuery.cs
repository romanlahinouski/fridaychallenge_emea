using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries
{
   public class GetDishesGrpcQuery : IRequest<IEnumerable<Dish>>
    {




    }
}
