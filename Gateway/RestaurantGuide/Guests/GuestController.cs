using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantGuide.Application.Guests.Commands;


namespace RestaurantGuide.Guests
{
    [Route("api/[controller]/[action]")]  
    [Produces("application/json")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator mediator;
  

        public GuestController(IMediator mediator)
        {
            this.mediator = mediator;          
        }

        [ProducesResponseType(StatusCodes.Status201Created)]   
        [HttpPost]    
        public async Task<ActionResult> Create([FromBody] CreateGuestRequest createGuestRequest)
        {       
            await mediator.Send(new CreateGuestCommand(createGuestRequest.PhoneNumber,
                createGuestRequest.FirstName,
                createGuestRequest.LastName,
                createGuestRequest.Email));

            return Created("",null);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterForAVisit([FromBody] RegisterGuestRequest registerGuestRequest )
        {
            await mediator.Send(new RegisterGuestCommand(
                registerGuestRequest.RestaurantId,
                registerGuestRequest.Email,
                registerGuestRequest.Phone,
                registerGuestRequest.Name,
                registerGuestRequest.Surname
                ));
        
            return Ok();         
        }
    }      
}