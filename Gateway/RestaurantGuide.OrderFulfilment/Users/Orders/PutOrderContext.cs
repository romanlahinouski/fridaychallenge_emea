using AutoMapper;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Users;
using RestaurantGuide.Domain.Users.Orders;
using RestaurantGuide.OrderFulfilment.Restaurants.Roles;
using RestaurantGuide.OrderFulfilment.Users.Roles.OrderingGuestRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class PutOrderContext : IPutOrderContext
    {
        private readonly IUserRepository userRepository;
        private readonly IDishRepository dishRepository;
        private readonly IOrderRestaurantRole orderRestaurantRole;
        private readonly IOrderingGuestRole orderingGuestRole;

        public PutOrderContext(
            IUserRepository userRepository,
            IDishRepository dishRepository,
            IOrderRestaurantRole orderRestaurantRole,
            IOrderingGuestRole orderingGuestRole
            )
        {
            this.userRepository = userRepository;
            this.dishRepository = dishRepository;
            this.orderRestaurantRole = orderRestaurantRole;
            this.orderingGuestRole = orderingGuestRole;
        }


        public async Task  PutOrder(List<DishItemDto> dishesDtos, int userId)
        {

            var user = await userRepository.GetUserById(userId);

           
            var dishes = dishRepository
                 .GetDishesByNames(dishesDtos.Select(d => d.DishName))
                 .ToList();


            var orderProducts = dishes.Select(d =>

            new OrderItem(d,
                    dishesDtos.Single(y => y.DishName == d.Name).Count
                    )
             ).ToList();

            var order = Order.CreateOrder(orderProducts);


#warning not implemented 
            //TODO: not imeplemended

            //orderRestaurantRole.AcceptOrder(order);



            orderingGuestRole.MakeOrder(order, user);
        }

    }
}
