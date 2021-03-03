using Microsoft.EntityFrameworkCore;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.OrderFulfilment.Infrastructure.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Dishes
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        private readonly OrderFulfilmentDbContext dbContext;

        public DishRepository(OrderFulfilmentDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

            //CreateRandomDishes();

            ////dbContext.SaveChanges();
        }

        //private void CreateRandomDishes()
        //{
        //    Random random = new Random();

        //    var dishesTmp = new List<Dish>();


        //    for (int i = 0; i < 10; i++)
        //    {
        //        var amountOfIngredients = random.Next(10);
        //        List<DishIngredient> dishIngredients = new List<DishIngredient>();

        //        StringBuilder dishName = new StringBuilder("");

        //        for (int x = 0; x < random.Next(0, 20); x++)
        //        {
        //            var ch = Convert.ToChar(random.Next(97, 122));
        //            dishName.Append(Convert.ToChar(random.Next(97, 122)));
        //        }

        //        for (int j = 0; j < amountOfIngredients; j++)
        //        {

        //            StringBuilder ingredientName = new StringBuilder("");

        //            for (int x = 0; x < random.Next(0, 20); x++)
        //            {
        //                ingredientName.Append(Convert.ToChar(random.Next(97, 122)));
        //            }


        //            dishIngredients.Add(new DishIngredient(random.Next(1, 1000000000), ingredientName.ToString(), "kg", random.Next(3)));
        //        }

        //        dishesTmp.Add(Dish.CreateDish(i, dishName.ToString(), dishIngredients, random.Next(10000)));
        //    }


        //    dbContext.Dishes.AddRange(dishesTmp);

        //}


        public async Task<List<Dish>> GetAll()
        {
            return await dbContext.Dishes.ToListAsync();
        }

        public Task<Dish> GetDish(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dish>> GetDishesByNames(IEnumerable<string> names)
        {
            return await dbContext.Dishes.Where(x => names.Contains(x.Name)).ToListAsync();
        }

        public async Task<List<Dish>> GetDishesByIds(IEnumerable<int> ids)
        {
            return await dbContext.Dishes.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
