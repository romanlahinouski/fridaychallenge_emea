using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Users;
using System;

namespace RestaurantGuide.OrderFulfilment.Users.Roles
{
    public interface IRegisteringUserRole : IBaseRole<User>
    {
        public void SetVisit(User user, Visit visit);
    }
}
