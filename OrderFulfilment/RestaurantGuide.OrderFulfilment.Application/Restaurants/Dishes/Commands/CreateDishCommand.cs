using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Commands
{
    public class CreateDishCommand : IRequest
    {
        public string DishName { get; set; }

        public string Price { get; set; }

        public string MyProperty { get; set; }


    }
}
