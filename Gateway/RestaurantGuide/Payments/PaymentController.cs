using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantGuide.Application.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.Payments
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PaymentRequest paymentRequest)
        {
            await mediator.Send(new CreatePaymentCommand(paymentRequest.OrderIdentifier, paymentRequest.Payment));

            return Ok();
        }

    }
}
