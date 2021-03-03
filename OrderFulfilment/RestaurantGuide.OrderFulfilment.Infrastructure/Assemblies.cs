using System.Reflection;
using App = RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries;
using Infra = RestaurantGuide.Infrastructure;

namespace RestaurantGuide.Infrastructure
{
    public static class Assemblies
    {
        public static Assembly Application { get; } = typeof(App.DishDto).Assembly;
        public static Assembly Infrastructure { get; } = typeof(Infra.Assemblies).Assembly;
      
        public static Assembly[] SolutionAsseblies { get; } = new Assembly[]
        {
            Application,
            Infrastructure,     
            
        };
    }
}
