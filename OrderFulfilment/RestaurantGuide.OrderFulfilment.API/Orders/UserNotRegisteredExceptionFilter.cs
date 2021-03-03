using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestaurantGuide.OrderFulfilment.Infrastructure;
using RestaurantGuide.OrderFulfilment.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.API.Orders
{
    public class GuestNotRegisteredExceptionFilter : ExceptionFilterAttribute
    {

        public GuestNotRegisteredExceptionFilter()
        {
        
        }
    
        public override void OnException(ExceptionContext context)
        {

            var ae = context.Exception as AggregateException;

            if (ae != null)
                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    var exec = e as GuestNotRegisterForAVisitException;

                    if (exec != null)
                    {
                        string errorMessage = $"Guest with id {exec.GuestId} is not register for a visit, please register a Guest first";
                                                                  
                        var result = new BadRequestObjectResult(errorMessage);
                        context.Result = result;
                    }
                    else
                    {
                        throw e;
                    }
                }
        }
    }
}
