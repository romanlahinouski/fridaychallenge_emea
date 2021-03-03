using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Domain.Base
{
    public abstract class Context
    {

        public Task Handle()
        {
            BeforeExecution();
            Execute();
            AfterExecution();

            return Task.CompletedTask;
        }


        protected virtual Task BeforeExecution()
        {
            throw new NotImplementedException();
        }

        protected virtual Task Execute()
        {
            throw new NotImplementedException();
        }

        protected virtual Task AfterExecution()
        {
            throw new NotImplementedException();
        }




    }
}
