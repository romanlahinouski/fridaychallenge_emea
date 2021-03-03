using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Users.Orders;

namespace RestaurantGuide.OrderFulfilment.Domain.Users
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
       
        //public Address Address { get; private set; }
    

        public int UserId { get; set; }

     
        public List<Visit> Visits { get; set; }
            = new List<Visit>();

        public User()
        {
            //EFCore
        }
        private  User(string firstName,
         string lastName,
         string email,
         string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
    
        }     
        public static User CreateUser(
            string firstName,
            string lastName,
            string email,
            string phoneNumber)
        {
            return new User(firstName, lastName, email, phoneNumber);
        }

 
        public void SetVisit(Visit visit)
        {         
            Visits.Add(visit);
        }

        public void MakeOrder(Order order)
        {
            Visits
                .Where(x => x.IsActive)
                .FirstOrDefault()
                .AddOrder(order);
        }

        public bool IsRegisteredForVisit()
        {
            return Visits
                .Where(v => v.IsActive)
                .Any();
        }
                
    }
}
