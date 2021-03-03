using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Domain.Visits;
using RestaurantGuide.OrderFulfilment.Domain.Guests;
using System;

namespace RestaurantGuide.OrderFulfilment.Guests.Roles
{
    public interface IRegisteringGuestRole : IBaseRole<Guest>
    {
        public void SetVisit(Guest Guest, Visit visit);
    }
}
