using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries
{
    public class GetDishesGrpcQueryHandler : IRequestHandler<GetDishesGrpcQuery, IEnumerable<Dish>>
    {
        private readonly IDishRepository dishRepository;

        public GetDishesGrpcQueryHandler(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        
        
        public async Task<IEnumerable<Dish>> Handle(GetDishesGrpcQuery request, CancellationToken cancellationToken)
        {
            return await dishRepository.GetAll();
        }
    }
}
