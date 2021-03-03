using AutoMapper;
using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Users.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Restaurants.Dishes.Queries
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

        public Task<IReadOnlyCollection<DishDto>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            var dishes = dishRepository.GetAll();
            var dishesDtos = mapper.Map<IReadOnlyCollection<DishDto>>(dishes);
            return Task.FromResult(dishesDtos);

        }
    }
}
