using AutoMapper;
using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries
{
    class GetDishesQueryHandler : IRequestHandler<GetDishesQuery,IReadOnlyCollection<DishDto>>
    {
        private readonly IDishRepository dishRepository;
        private readonly IMapper mapper;

        public GetDishesQueryHandler(IDishRepository dishRepository,
            IMapper mapper
            )
        {
            this.dishRepository = dishRepository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyCollection<DishDto>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            var dishes = await dishRepository.GetAll();
            var dishesDtos = mapper.Map<IReadOnlyCollection<DishDto>>(dishes);
            return dishesDtos;

        }
    }
}
