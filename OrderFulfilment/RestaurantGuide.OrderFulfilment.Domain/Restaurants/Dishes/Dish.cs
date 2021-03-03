using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;
using RestaurantGuide.OrderFulfilment.Domain.Restaurants.Dishes;
using System;
using System.Collections.Generic;

namespace RestaurantGuide.Domain.Restaurants.Dishes
{
    public class Dish
    {

    
        public decimal Price { get; set; }
        public string Description  { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DishDishIngredient> Ingredients { get ; set; }

        public Dish()
        {
            //ef core only
        }

        private Dish(int id, 
            string name,
            List<DishDishIngredient> ingredients,
            decimal price,
            string description = default)
        {
            Name = name;          
            Price = price;
            Description = description;
            Id = id;

           Ingredients = ingredients;

        }

        public static Dish CreateDish(int id,
            string name, 
            List<DishDishIngredient> ingredients,
            decimal price)
        {
            return new Dish(id, name, ingredients, price);
        }
      
      
        public decimal GetPrice()
        {
            return Price;
        }

    }
}
