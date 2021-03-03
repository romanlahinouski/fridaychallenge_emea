using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Guests;


namespace RestaurantGuide.OrderFulfilment.Guests.Roles
{
    public class RegisteringGuestRole : IRegisteringGuestRole
    {
       
        public RegisteringGuestRole()
        {
           
        }

        //public Guest GetValue()
        //{
        //    return Guest;
        //}

        public void SetVisit(Guest Guest,Visit visit)
        {
            Guest.SetVisit(visit);
        }
    }
}
