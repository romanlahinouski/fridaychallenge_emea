using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Infrastructure.Base;

namespace RestaurantGuide.Infrastructure.Guests
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        private readonly GuestDbContext userDbContext;


        public GuestRepository(GuestDbContext userDbContext)
            : base(userDbContext)
        {
            this.userDbContext = userDbContext;
        }

       
        public async Task<Guest> GetGuestByEmail(string email)
        {
            return await userDbContext.Guests.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Guest> GetGuestById(int useriD)
        {
            return await userDbContext.FindAsync<Guest>(useriD);
        }
    }
}
