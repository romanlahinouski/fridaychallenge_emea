using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.OrderFulfilment.Domain.Users;

namespace RestaurantGuide.Domain.Restaurants
{
    public interface IRestaurantRepository : IRepository
    {
        public Task<IReadOnlyCollection<Restaurant>> GetAll();
  
        public IReadOnlyCollection<User> GetRestaurantUsers(int restaurantId);

        public Task<Restaurant> GetRestaurantById(int restaurantId);

        public Task AddRestaurant(Restaurant restaurant);
    }
}
