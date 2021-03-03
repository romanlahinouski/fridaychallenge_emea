using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Restaurants.Dishes.Ingredients;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using System;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Guests
{
    public class OrderFulfilmentDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishDishIngredient> DishDishIngredients { get; set; }

        public static readonly ILoggerFactory loggerFactory
   = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public OrderFulfilmentDbContext(DbContextOptions<OrderFulfilmentDbContext> options)
            : base(options)
        {

        }

        public OrderFulfilmentDbContext(DbContextOptions options, bool isChainInit)
         : base(options)
        {

        }




        public OrderFulfilmentDbContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Guest>()
                .ToTable("Guests");
            modelBuilder
                .Entity<Guest>()
                .HasKey(v => v.GuestId);
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
              .Property<string>("Email")
              .HasColumnName("Email")
              .IsRequired();
            modelBuilder
               .Entity<Guest>()
               .Property<string>("PhoneNumber")
               .HasColumnName("PhoneNumber")
               .IsRequired();
            modelBuilder
              .Entity<Guest>()
              .HasMany(x => x.Visits);


            modelBuilder
                .Entity<Visit>()
                .HasKey(v => v.VisitId);
            modelBuilder
                .Entity<Visit>()
                .Property<DateTime>("TimeStart")
                .HasColumnName("TimeStart");
            modelBuilder
                .Entity<Visit>()
                .Property<DateTime>("TimeEnd")
                .HasColumnName("TimeEnd");
            modelBuilder
                .Entity<Visit>()
                .Property<Decimal>("Paycheck")
                .HasColumnName("Paycheck");

            modelBuilder
              .Entity<Visit>()
              .Property<bool>("IsActive")
              .HasColumnName("IsActive");

            modelBuilder
                .Entity<Order>()
                .HasKey(v => v.OrderId);

            modelBuilder
                .Entity<Order>()
                .Property<OrderStatus>("OrderStatus").HasColumnName("OrderStatus");
            modelBuilder
                .Entity<Order>()
                .HasMany<OrderItem>(x => x.OrderItems);

            modelBuilder
                .Entity<OrderItem>()
                .ToTable("OrderItems");

            modelBuilder
                .Entity<Dish>()
                .ToTable("Dishes");
           
            modelBuilder
                .Entity<DishIngredient>()
                .ToTable("DishIngredients");

            modelBuilder
                .Entity<DishDishIngredient>()
                .ToTable("DishDishIngredients");

            modelBuilder
                .Entity<DishDishIngredient>()
                .HasKey(x => new { x.DishId, x.IngredientId });

            modelBuilder
                .Entity<DishDishIngredient>()
                .HasOne<Dish>()
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.DishId);

            modelBuilder
               .Entity<DishDishIngredient>()
               .HasOne<DishIngredient>()
               .WithMany(x => x.Dishes)
               .HasForeignKey(x => x.IngredientId);
               
            //modelBuilder
            //    .Entity<Dish>()
            //    .HasMany(p => p.Ingredients).WithMany(p => p.)
            //    .UsingEntity(j => j.ToTable("PostTags"));

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder.UseMySql("Server=localhost,port=3306;Database=RestaurantsDB;Uid=root;Pwd=1111;"));
        //    optionsBuilder.UseLoggerFactory(loggerFactory);
        //}
    }
}
