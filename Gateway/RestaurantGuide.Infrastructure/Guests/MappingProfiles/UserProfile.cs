using AutoMapper;
using RestaurantGuide.Application.Guests;
using RestaurantGuide.Domain.Guests;

namespace RestaurantGuide.Infrastructure.Guests.MappingProfiles
{
    public partial class GuestProfile : Profile
    {
        public GuestProfile()
        {

            DefaultMemberConfig.AddName<CaseInsensitiveName>();

            CreateMap<Guest, GuestDto>();        
        }
    }
}
