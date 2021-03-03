using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Restaurants.RestaurantGuests;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants
{
    public class RestaurantDbContext : DbContext
    {

        public static readonly ILoggerFactory loggerFactory
       = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public DbSet<Restaurant> Restaurants { get; set; }


        public RestaurantDbContext()
        {

        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {

        }

        public RestaurantDbContext(DbContextOptions options, bool isChainInit) : base(options)
        {
            //IDesignTimeDbContextFactory only
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property("maxNumberOfGuests").HasColumnName("MaxNumberOfGuests");

            modelBuilder.Entity<Restaurant>()
                .HasMany<RestaurantGuest>();

            modelBuilder.Entity<RestaurantGuest>().ToTable("RestaurantGuests");

        }

    }
}