using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles;
using RestaurantGuide.OrderFulfilment.Users.Roles;
using System;
using System.Threading.Tasks;


namespace RestaurantGuide.OrderFulfilment.Application
{
    public class UserRegistrationContext : IUserRegistrationContext
    {
        private readonly IRegistrationRestaurantRole registrationRestaurantRole;
        private readonly IRegisteringUserRole registeringUserRole;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;

        public UserRegistrationContext(IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IRegistrationRestaurantRole registrationRestaurantRole,
            IRegisteringUserRole registeringUserRole
            )           
        {         
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.registrationRestaurantRole = registrationRestaurantRole;
            this.registeringUserRole = registeringUserRole;
        }

        //public void Test()
        //{
        //    IBaseRole<Restaurant> baseRole = new RegistrationRestaurantRole();
        //}

        //userId -> email(string)

        public async Task RegisterUser(RegisterUserCommand request)
        {
           
           var restaurant = await restaurantRepository.GetRestaurantById(request.RestaurantId);

            if(restaurant == null)
            {

                throw new ArgumentNullException("Restaurant is not present in the system");
            }                
           
           
           var user = await userRepository.GetUserByEmail(request.Email);

             if(user == null)
            {
                throw new ArgumentNullException("User is not present in the system");
            }

            registrationRestaurantRole.RegisterUser(user, restaurant);

            var visit = Visit.CreateVisit(request.RestaurantId, DateTime.Now, 0);

            registeringUserRole.SetVisit(user, visit);
       
            userRepository.Update(user);
       
            await userRepository.SaveChangesAsync();
           
        }
    }
}
