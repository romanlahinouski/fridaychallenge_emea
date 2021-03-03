using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Domain.Restaurants.RestaurantGuests;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Domain.Visits;

namespace RestaurantGuide.Infrastructure.Guests
{
    public class GuestDbContext : DbContext
    {

        public DbSet<Guest> Guests { get; set; }

  
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
        {

        }

        public GuestDbContext(DbContextOptions options, bool isChainInit) : base(options)
        {
            //IDesignTimeDbContextFactory only
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().ToTable("Guests");

            modelBuilder.Entity<Guest>().HasKey(x => x.GuestId);

            modelBuilder
                .Entity<Guest>()
                .Property<string>("FirstName")
                .HasColumnName("FirstName");
            modelBuilder
                .Entity<Guest>()
                .Property<string>("LastName")
                .HasColumnName("LastName");
            modelBuilder
                .Entity<Guest>()
                .Property<string>("PhoneNumber")
                .HasColumnName("PhoneNumber");

        }


   
    }
}



