using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestaurantGuide.Guests;
using RestaurantGuide.Modules;
using System;
using RestaurantGuide.Infrastructure.Guests;
using Microsoft.Extensions.Hosting;
using RestaurantGuide.Infrastructure.Orders.Protos;
using RestaurantGuide.Application.Payments;
using RestaurantGuide.Infrastructure.Payments;
using Microsoft.Extensions.Logging;
using RestaurantGuide.Middleware;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.API.Guests.Protos;

namespace RestaurantGuide
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;
           
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            ILoggerFactory loggerFactory
              = LoggerFactory.Create(builder => { builder.AddConsole(); });

         

            var orderfulfilmentServiceUrl = new Uri(configuration["GrpcOrderFulfilementServiceURL"]);
            var administrationServiceUrl = new Uri(configuration["GrpcRestaurantAdministrationServiceURL"]);

            string dbConnectionString = configuration["ConnectionString"];

            if (String.IsNullOrEmpty(configuration["DbPassword"]))
                throw new ArgumentException("DbPassword wasn't supplied, set db password as env variable or cli argument like DbPassword=<your password>");

            if (env.IsProduction()) {
             dbConnectionString =String.Concat(configuration["ConnectionString"],
                 $"Pwd={configuration["DbPassword"]};");
            }
          
            services.AddHttpContextAccessor();

            services.AddHttpClient<IPaymentCreationService, PaymentCreationService>("defaultClient", options =>
            {

                options.BaseAddress = new Uri("https://localhost:5001/api/");
                options.DefaultRequestHeaders.Add("Content-Type", "application/json");
            });

            services.AddGrpcClient<GuestRegistrationServiceProto.GuestRegistrationServiceProtoClient>(options =>
            {

                options.Address = orderfulfilmentServiceUrl;


            }).ConfigureHttpMessageHandlerBuilder((builder) =>
            {
                builder.PrimaryHandler = new SkipCertValidationHttpHandler(configuration);

            }); ;

            services.AddGrpcClient<OrderFulfilmentServiceProto.OrderFulfilmentServiceProtoClient>(options =>
            {

                options.Address = orderfulfilmentServiceUrl;

            }).ConfigureHttpMessageHandlerBuilder((builder) =>
            {
                builder.PrimaryHandler = new SkipCertValidationHttpHandler(configuration);

            });
            
            services.AddControllers(
                options =>
                {
                  
                }).AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new DateTimeConverter());

                });

            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
             {
                 options.Authority = "https://localhost:6001";
                
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
            
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "RestaurantGuide.Web");

                });

            });

            services.AddDbContext<GuestDbContext>(options =>
            {
                options.UseMySql(dbConnectionString);
                options.UseLoggerFactory(loggerFactory);
            });

            services.AddSwaggerGen();
        }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;       
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new AutomapperModule());
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRequestLocalization(new string[] { "pl-PL" });

     
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //adds route matching to the middleware pipeline.
            //This middleware looks at the set of endpoints defined in the app, and selects the best match based on the request.
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(async (context,next) => 
            {

                if (context.Request.Path.Value.Contains("info"))
                {
                    await context.Response.WriteAsync($"2. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");                  
                }

                await next.Invoke();
            });

            app.UseAuthentication();
            app.UseAuthorization();

          
            app.UseEndpoints(endpoints => 
            {                
                endpoints.MapControllers();
            });


        }
    }
}
