using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.Domain.Restaurants.Addresses;
using RestaurantGuide.Domain.Guests.Orders;
using RestaurantGuide.Domain.Visits;

namespace RestaurantGuide.Domain.Guests
{
    public class Guest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
       
        //public Address Address { get; private set; }
    

        public int GuestId { get; set; }

        private List<Visit> visits
            = new List<Visit>();

        public Guest()
        {
            //EFCore
        }
        private  Guest(string firstName,
         string lastName,
         string email,
         string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
    
        }

        public static Guest CreateGuest(string firstName,
            string lastName,
            string email,
            string phoneNumber)
        {
            return new Guest(firstName, lastName, email, phoneNumber);
        }

        public void SetVisit(int tmpId, int restaurantId)
        {
            visits.Add(Visit.CreateVisit(tmpId, restaurantId));
        }
       
        public void MakeOrder(Order order)
        {
            visits
                .Where(x => x.IsActive)
                .FirstOrDefault()
                .AddOrder(order);
        }

        public bool IsRegisteredForVisit()
        {
            return visits.Where(v => v.IsActive).Any();
        }
                
    }
}
