using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles;
using RestaurantGuide.OrderFulfilment.Application.Guests.Orders;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using RestaurantGuide.OrderFulfilment.Guests.Roles.OrderingGuestRole;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Guests.Orders
{
    public class PutOrderContext : IPutOrderContext
    {
        private readonly IGuestRepository GuestRepository;
        private readonly IDishRepository dishRepository;
        private readonly IOrderRestaurantRole orderRestaurantRole;
        private readonly IOrderingGuestRole orderingGuestRole;

        public PutOrderContext(
            IGuestRepository GuestRepository,
            IDishRepository dishRepository,
            IOrderRestaurantRole orderRestaurantRole,
            IOrderingGuestRole orderingGuestRole
            )
        {
            this.GuestRepository = GuestRepository;
            this.dishRepository = dishRepository;
            this.orderRestaurantRole = orderRestaurantRole;
            this.orderingGuestRole = orderingGuestRole;
        }


        public async Task  PutOrder(List<OrderItemDto> dishesDtos, int GuestId)
        {

            var Guest = await GuestRepository.GetGuestById(GuestId);


            var dishes = await dishRepository
                 .GetDishesByIds(dishesDtos.Select(d => d.DishId));
              
            var orderProducts = dishes.Select(d =>

            new OrderItem(d,
                    dishesDtos.Single(y => y.DishId == d.Id).Count
                    )
             ).ToList();

            var order = Order.CreateOrder(orderProducts);


#warning not implemented 
            //TODO: not imeplemended

            //orderRestaurantRole.AcceptOrder(order);



            orderingGuestRole.MakeOrder(order, Guest);


            GuestRepository.Update(Guest);

            await  GuestRepository.SaveChangesAsync();
        }

    }
}
