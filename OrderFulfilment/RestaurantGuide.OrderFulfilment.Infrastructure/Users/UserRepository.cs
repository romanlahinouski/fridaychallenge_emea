using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Guests
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        private readonly OrderFulfilmentDbContext GuestDbContext;      
        private readonly IConfiguration configuration;

        public GuestRepository(OrderFulfilmentDbContext GuestDbContext,                  
            IConfiguration configuration
            )
            : base(GuestDbContext)
        {
            this.GuestDbContext = GuestDbContext;        
            this.configuration = configuration;
        }


        public async Task<Guest> GetGuestByEmail(string email)
        {          
            var Guest = await GuestDbContext.Guests
                 .Include(x => x.Visits)
                 .ThenInclude(x => x.Order)
                 .FirstOrDefaultAsync(x => x.Email == email);     
            return Guest;
        }

        public async Task<Guest> GetGuestById(int GuestiD)
        {
           
            
            return await GuestDbContext.Guests
              .Include(x => x.Visits)
              .ThenInclude(x => x.Order)
              .FirstOrDefaultAsync(x => x.GuestId == GuestiD);
        }
    }
}
