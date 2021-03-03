using MediatR;
using RestaurantGuide.Domain.Restaurants.Dishes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.Application.Orders.Queries
{
    public class GetDishesQueryHandler : IRequestHandler<GetDishesQuery, IReadOnlyCollection<Dish>>
    {
        private readonly IOrderFulfilmentService orderFulfilmentService;

        public GetDishesQueryHandler(IOrderFulfilmentService orderFulfilmentService)
        {
            this.orderFulfilmentService = orderFulfilmentService;
        }
        
        public async Task<IReadOnlyCollection<Dish>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            var dishes = await orderFulfilmentService.GetDishes();

            return dishes;
        }
    }
}
