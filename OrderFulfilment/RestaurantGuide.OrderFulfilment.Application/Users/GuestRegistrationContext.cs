using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Application.Restaurants;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles;
using RestaurantGuide.OrderFulfilment.Guests.Roles;
using System;
using System.Threading.Tasks;


namespace RestaurantGuide.OrderFulfilment.Application
{
    public class GuestRegistrationContext : IGuestRegistrationContext
    {
        private readonly IRegistrationRestaurantRole registrationRestaurantRole;
        private readonly IRegisteringGuestRole registeringGuestRole;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IGuestRepository GuestRepository;

        public GuestRegistrationContext(IRestaurantRepository restaurantRepository,
            IGuestRepository GuestRepository,
            IRegistrationRestaurantRole registrationRestaurantRole,
            IRegisteringGuestRole registeringGuestRole
            )           
        {         
            this.restaurantRepository = restaurantRepository;
            this.GuestRepository = GuestRepository;
            this.registrationRestaurantRole = registrationRestaurantRole;
            this.registeringGuestRole = registeringGuestRole;
        }

        //public void Test()
        //{
        //    IBaseRole<Restaurant> baseRole = new RegistrationRestaurantRole();
        //}

        //GuestId -> email(string)

        public async Task RegisterGuest(RegisterGuestCommand request)
        {
           
           var restaurant = await restaurantRepository.GetRestaurantById(request.RestaurantId);

            if(restaurant == null)
            {

                throw new ArgumentNullException("Restaurant is not present in the system");
            }                
           
           
           var Guest = await GuestRepository.GetGuestByEmail(request.Email);

             if(Guest == null)
            {
                throw new ArgumentNullException("Guest is not present in the system");
            }

            registrationRestaurantRole.RegisterGuest(Guest, restaurant);

            var visit = Visit.CreateVisit(request.RestaurantId, DateTime.Now, 0);

            registeringGuestRole.SetVisit(Guest, visit);
       
            GuestRepository.Update(Guest);
       
            await GuestRepository.SaveChangesAsync();
           
        }
    }
}
