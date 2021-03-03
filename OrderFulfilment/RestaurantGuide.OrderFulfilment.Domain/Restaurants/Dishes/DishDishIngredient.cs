using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Domain.Restaurants.Dishes
{
   public class DishDishIngredient
    {

        public int DishDishIngredientId { get; set; }

        public int DishId { get; set; }

        public int IngredientId { get; set; }
    }
}
