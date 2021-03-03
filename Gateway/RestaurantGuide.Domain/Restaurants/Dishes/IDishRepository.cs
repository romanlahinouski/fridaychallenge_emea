using RestaurantGuide.Domain.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Domain.Restaurants.Dishes
{
    public interface IDishRepository
    {
        public Dish GetDish(int id);

        public List<Dish> GetDishesByNames(IEnumerable<string> names);

        public List<Dish> GetAll();

    }
}
