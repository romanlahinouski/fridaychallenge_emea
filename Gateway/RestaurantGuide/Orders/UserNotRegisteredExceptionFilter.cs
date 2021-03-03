using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantGuide.Application.Orders;

namespace RestaurantGuide.Orders.Administration
{
    public class GuestNotRegisteredExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            var ae = context.Exception as AggregateException;

            if (ae != null)
                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    var exec = e as GuestNotRegisterForAVisitException;

                    if (exec != null)
                    {
                        var result = new BadRequestObjectResult($"Guest with id {exec.GuestId} is not register for a visit, please register a user first");
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
