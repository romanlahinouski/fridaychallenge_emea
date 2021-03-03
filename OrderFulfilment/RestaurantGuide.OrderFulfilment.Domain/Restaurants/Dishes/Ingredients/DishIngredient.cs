using System;
using System.Collections.Generic;
using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;
using RestaurantGuide.OrderFulfilment.Domain.Restaurants.Dishes;

namespace RestaurantGuide.Domain.Restaurants.Dishes.Ingredients
{
    public class DishIngredient
    {

        public int DishIngredientId { get; private set; }

        public List<DishDishIngredient> Dishes { get; private set; } 
            = new List<DishDishIngredient>();

        public DishIngredient()
        {
            //ef core only
        }

        public DishIngredient(int id, string name,string unitType, float amount)
        {
            Name = name;
            UnitType = unitType;
            Amount = amount;
            DishIngredientId = id;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string UnitType { get; set; }
        public float Amount { get; set; }


    }
}
