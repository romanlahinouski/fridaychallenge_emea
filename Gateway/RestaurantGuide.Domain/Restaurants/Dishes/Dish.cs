using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;
using System;
using System.Collections.Generic;

namespace RestaurantGuide.Domain.Restaurants.Dishes
{
    public class Dish
    {

        private decimal price;
        private string description;
     

        public int Id { get; set; }
        public string Name { get; set; }


        private Dish(int id, 
            string name,
            List<DishIngredient> ingredients,
            decimal price,
            string description = default)
        {
            this.Name = name;
            this.ingredients = ingredients;
            this.price = price;
            this.description = description;
            this.Id = id;

        }

        public static Dish CreateDish(int id,
            string name, 
            List<DishIngredient> ingredients,
            decimal price)
        {
            return new Dish(id, name, ingredients, price);
        }
      
        private List<DishIngredient> ingredients 
            = new List<DishIngredient>();


        public decimal GetPrice()
        {
            return price;
        }

    }
}
