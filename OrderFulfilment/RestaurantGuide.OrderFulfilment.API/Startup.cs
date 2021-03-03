using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Infrastructure.Restaurants;
using RestaurantGuide.OrderFulfilment.Infrastructure;
using RestaurantGuide.OrderFulfilment.Infrastructure.Orders;
using RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants;
using RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Infrastructure.Guests;
using RestaurantGuide.OrderFulfilment.Modules;

namespace RestaurantGuide.OrderFulfilment.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
        
            this.configuration = configuration;
            this.env = env;
        }

      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


            string dbConnectionString = configuration["ConnectionString"];

            if (String.IsNullOrEmpty(configuration["DbPassword"]))
                throw new ArgumentException("DbPassword wasn't supplied, set db password as env variable or cli argument like DbPassword=<your password>");

            if (env.IsProduction())
            {
                dbConnectionString = String.Concat(configuration["ConnectionString"],
                    $"Pwd={configuration["DbPassword"]};");
            }

            services.AddGrpc();

            services.AddDbContext<OrderFulfilmentDbContext>(options =>
            {
                options.UseMySql(dbConnectionString);
            });

            services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseMySql(dbConnectionString);
          
            });
                            
            services.AddControllers();           
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new AutomapperModule());
            builder.RegisterModule(new OrderFulfilmentModule());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            //app.UseMiddleware<AppDynamicsHandlerMiddleware>();
            
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<OrderFulfimentGrpcService>();
                endpoints.MapGrpcService<GuestRegistrationService>();
            });
        }
    }
}
