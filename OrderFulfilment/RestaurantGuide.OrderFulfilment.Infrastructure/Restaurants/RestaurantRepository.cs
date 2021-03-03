using Microsoft.EntityFrameworkCore;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly RestaurantDbContext restaurantDbContext;

        public RestaurantRepository(RestaurantDbContext restaurantDbContext)
            : base(restaurantDbContext)
        {
            this.restaurantDbContext = restaurantDbContext;
        }

        public Task<IReadOnlyCollection<Restaurant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            return await restaurantDbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == restaurantId);
        }

        public IReadOnlyCollection<User> GetRestaurantUsers(int restaurantId)
        {
            throw new NotImplementedException();
        }

  
        public async Task AddRestaurant(Restaurant restaurant)
        {
            await restaurantDbContext.AddAsync(restaurant);
            await restaurantDbContext.SaveChangesAsync();
        }

       
        public async Task<IReadOnlyCollection<Restaurant>> GetRestaurantWithUserIncluded(int restaurantId)
        {
            var restaurants = await restaurantDbContext.Restaurants
                .Where(r => r.Id == restaurantId)
                .Include("currentUsers")
                .ToListAsync();

            //var users = restaurant.

            return restaurants;
        }

       
    }
}
