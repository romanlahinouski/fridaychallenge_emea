using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Roles;
using RestaurantGuide.OrderFulfilment.Application.Users.Orders;
using RestaurantGuide.OrderFulfilment.Domain.Users.Orders;
using RestaurantGuide.OrderFulfilment.Users.Roles.OrderingUserRole;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class PutOrderContext : IPutOrderContext
    {
        private readonly IUserRepository userRepository;
        private readonly IDishRepository dishRepository;
        private readonly IOrderRestaurantRole orderRestaurantRole;
        private readonly IOrderingUserRole orderingUserRole;

        public PutOrderContext(
            IUserRepository userRepository,
            IDishRepository dishRepository,
            IOrderRestaurantRole orderRestaurantRole,
            IOrderingUserRole orderingUserRole
            )
        {
            this.userRepository = userRepository;
            this.dishRepository = dishRepository;
            this.orderRestaurantRole = orderRestaurantRole;
            this.orderingUserRole = orderingUserRole;
        }


        public async Task  PutOrder(List<OrderItemDto> dishesDtos, int userId)
        {

            var user = await userRepository.GetUserById(userId);


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



            orderingUserRole.MakeOrder(order, user);


            userRepository.Update(user);

            await  userRepository.SaveChangesAsync();
        }

    }
}
