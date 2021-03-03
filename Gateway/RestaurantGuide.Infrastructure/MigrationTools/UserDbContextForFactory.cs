using Microsoft.EntityFrameworkCore;
using RestaurantGuide.Infrastructure.Guests;

namespace RestaurantGuide.Infrastructure.MigrationTools
{
    public class GuestDbContextForFactory : GuestDbContext
    {

        public GuestDbContextForFactory(DbContextOptions<GuestDbContextForFactory> options) 
            : base(options, true)
        {

        }
    }
}