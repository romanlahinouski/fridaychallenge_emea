using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly OrderFulfilmentDbContext userDbContext;      
        private readonly IConfiguration configuration;

        public UserRepository(OrderFulfilmentDbContext userDbContext,                  
            IConfiguration configuration
            )
            : base(userDbContext)
        {
            this.userDbContext = userDbContext;        
            this.configuration = configuration;
        }


        public async Task<User> GetUserByEmail(string email)
        {          
            var user = await userDbContext.Users
                 .Include(x => x.Visits)
                 .ThenInclude(x => x.Order)
                 .FirstOrDefaultAsync(x => x.Email == email);     
            return user;
        }

        public async Task<User> GetUserById(int useriD)
        {
           
            
            return await userDbContext.Users
              .Include(x => x.Visits)
              .ThenInclude(x => x.Order)
              .FirstOrDefaultAsync(x => x.UserId == useriD);
        }
    }
}
