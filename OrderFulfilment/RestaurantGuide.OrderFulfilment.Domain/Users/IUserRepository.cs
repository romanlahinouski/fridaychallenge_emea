using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantGuide.Domain.Base;
using RestaurantGuide.OrderFulfilment.Domain.Guests;

namespace RestaurantGuide.Domain.Guests
{
    public interface IGuestRepository : IRepository
    {
        public Task<Guest> GetGuestById(int GuestiD);

        public Task Add(Guest Guest);

        public Task<Guest> GetGuestByEmail(string email);

        public void Update(Guest Guest);


    }
}
