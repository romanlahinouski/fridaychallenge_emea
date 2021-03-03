using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantGuide.Domain.Base;
using RestaurantGuide.OrderFulfilment.Domain.Users;

namespace RestaurantGuide.Domain.Users
{
    public interface IUserRepository : IRepository
    {
        public Task<User> GetUserById(int useriD);

        public Task Add(User user);

        public Task<User> GetUserByEmail(string email);

        public void Update(User user);


    }
}
