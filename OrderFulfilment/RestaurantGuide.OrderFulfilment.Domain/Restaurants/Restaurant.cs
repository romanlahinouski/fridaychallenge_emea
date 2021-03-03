using RestaurantGuide.Domain.Restaurants.Addresses;
using RestaurantGuide.Domain.Restaurants.Cuisines;
using RestaurantGuide.Domain.Restaurants.RestaurantUsers;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantGuide.Domain.Restaurants
{
    public class Restaurant
    {

        public int Id { get; private set; }

        public string RestaurantName { get;  private set; }

        public int? Stars { get;  private set; }

        public float Rating { get; private set; }

        public Cuisine Cuisine { get; private set; }


        private List<RestaurantUser> currentUsers
            = new List<RestaurantUser>();

        public string Street { get; private set; }
        public string City { get; private set; }
    
        private  int maxNumberOfGuests;

        public string Description { get;  private set; }


        public Restaurant()
        {
            //Ef core
        }

        private Restaurant(string restaurantName,
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default)
        {
            RestaurantName = restaurantName;
            Cuisine = cuisine;
            City = city;
            Street = street;
            Description = description;

            this.maxNumberOfGuests = maxNumberOfGuests;
                              
        }

        private Restaurant(int id,
            string restaurantName,
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default) :

            this(restaurantName,maxNumberOfGuests,cuisine,city,street,description)
        {
            Id = id;        
        }


        public static Restaurant CreateRestaurant(
            string restaurantName, 
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default)
        {
            return new Restaurant(restaurantName, maxNumberOfGuests, cuisine, city,street, description);
        }

        public static Restaurant CreateRestaurant(
            int id,
            string restaurantName,
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default)
        {
            return new Restaurant(id, restaurantName, maxNumberOfGuests, cuisine, city, street, description);
        }

        public int GetMaxNumberOfGuests()
        {
            return maxNumberOfGuests;
        }

        public int GetCurrentNumberOfUsers()
        {
            return currentUsers.Count;
        }

        public void RegisterUser(User user)
        {

            var restaurantUser = new RestaurantUser { UserId = user.UserId, RestaurantId = Id };


            currentUsers.Add(restaurantUser);
        }


        //public IReadOnlyCollection<User> GetCurrentUsers()
        //{
        //    return currentUsers.Select(u =;
        //}

        public int GetRemainingCapacity()
        {
            return maxNumberOfGuests - currentUsers.Count;
        }
    }
}
