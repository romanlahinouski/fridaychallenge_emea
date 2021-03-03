using System.Collections.Generic;
using RestaurantGuide.Domain.Base;

namespace RestaurantGuide.Domain.DomainServices
{
    public interface IPropertyToSpecificationMapper
    {
        IEnumerable<ISpecification> Map(params (string Name, object Value) []  propeties);
    }
}