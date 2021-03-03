using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestaurantGuide.Infrastructure.MigrationTools
{
    class GuestDbContextFactory : IDesignTimeDbContextFactory<GuestDbContextForFactory>
    {
        public GuestDbContextForFactory CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.Production.json")
               .Build();
            var builder = new DbContextOptionsBuilder<GuestDbContextForFactory>();
            var connectionString = configuration["ConnectionString"];
            builder.UseMySql(connectionString);
            return new GuestDbContextForFactory(builder.Options);
        }      
    }
}
