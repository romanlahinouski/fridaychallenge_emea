using System;
using System.Threading.Tasks;

namespace RestaurantGuide.Domain.Base
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    
    }
}
