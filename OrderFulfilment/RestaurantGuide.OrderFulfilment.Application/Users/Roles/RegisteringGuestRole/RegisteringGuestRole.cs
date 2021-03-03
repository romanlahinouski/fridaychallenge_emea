using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Users;


namespace RestaurantGuide.OrderFulfilment.Users.Roles
{
    public class RegisteringUserRole : IRegisteringUserRole
    {
       
        public RegisteringUserRole()
        {
           
        }

        //public User GetValue()
        //{
        //    return user;
        //}

        public void SetVisit(User user,Visit visit)
        {
            user.SetVisit(visit);
        }
    }
}
