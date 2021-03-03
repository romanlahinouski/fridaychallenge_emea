using System.Linq.Expressions;

namespace RestaurantGuide.Domain.Base
{
    public interface ISpecification
    {
        public Expression ToExpression(ParameterExpression restaurant);
    }
}