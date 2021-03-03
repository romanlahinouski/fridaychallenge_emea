using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantGuide.Domain.Base;

namespace RestaurantGuide.Domain.Guests
{
    public interface IGuestRepository : IRepository
    {
        public Task<Guest> GetGuestById(int useriD);

        public Task Add(Guest user);

        public Task<Guest> GetGuestByEmail(string email);
    }
}
