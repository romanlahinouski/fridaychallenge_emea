using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries
{
  public  class DishDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Decimal Price { get; set; }
    }
}
