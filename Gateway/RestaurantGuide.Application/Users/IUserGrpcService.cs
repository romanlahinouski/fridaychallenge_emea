using RestaurantGuide.Application.Guests.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.Application.Guests
{
    public interface IGuestGrpcService
    {
        public Task RegisterForAVisitAsync(RegisterGuestCommand registerGuestCommand);
    }
}
