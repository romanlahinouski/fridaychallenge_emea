using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries;
using RestaurantGuide.OrderFulfilment.Guests.Orders;

namespace RestaurantGuide.OrderFulfilment.API.Orders
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [TypeFilter(typeof(GuestNotRegisteredExceptionFilter))]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;          
        }

        [HttpPost]       
        public async Task<ActionResult> Put([FromBody] OrderDto orderDto)
        {     
            await mediator.Send(new PutOrderCommand(
                orderDto.Dishes.ToList(), 
                orderDto.GuestId));
        
            return Ok("Order Received");
        }

       
        [HttpGet]
        public Task<ActionResult> GetDishes()
        {
            var dishes = mediator.Send(new GetDishesQuery()).Result;

            return Task.FromResult<ActionResult>(Ok(dishes));
        }
    }
}
