using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.Domain.Restaurants.Dishes
{
    public interface IDishRepository
    {
        public Task<Dish> GetDish(int id);

        public Task<List<Dish>> GetDishesByNames(IEnumerable<string> names);

        public Task<List<Dish>> GetAll();

        public Task<List<Dish>> GetDishesByIds(IEnumerable<int> ids);

    }
}
