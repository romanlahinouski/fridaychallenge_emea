using System;
using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;

namespace RestaurantGuide.Domain.Restaurants.Dishes.Ingredients
{
    public class DishIngredient
    {

        public DishIngredient(string name,IngredientAmount ingredientAmount)
        {
            Name = name;
            IngredientAmount = ingredientAmount;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public IngredientAmount IngredientAmount { get; set; }

    }
}
