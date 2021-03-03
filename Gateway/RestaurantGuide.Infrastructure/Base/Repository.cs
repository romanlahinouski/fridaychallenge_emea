using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantGuide.Infrastructure.Base
{
    public abstract class Repository<T>
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(T entity)
        {
            await dbContext.AddAsync(entity);
            await SaveChanges();
        }
    }
}
