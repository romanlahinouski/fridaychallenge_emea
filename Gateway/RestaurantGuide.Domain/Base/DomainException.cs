using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Domain.Base
{
    public abstract class DomainException : Exception
    {

        public DomainException(string message)
            : base(message)
        {

        }
    }
}
