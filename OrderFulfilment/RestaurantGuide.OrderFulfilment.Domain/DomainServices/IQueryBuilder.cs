using RestaurantGuide.Domain.Base;
using RestaurantGuide.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantGuide.Domain.DomainServices
{
    public interface IQueryBuilder<T>
    {
        Expression<Func<T,bool>> Build(IEnumerable<ISpecification> expressions);
    }
}