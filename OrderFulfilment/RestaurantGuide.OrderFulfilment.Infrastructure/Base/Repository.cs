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

      
        public async Task Add(T entity)
        {
            await dbContext.AddAsync(entity);
            await SaveChangesAsync();
        }

         public async Task SaveChangesAsync()
        {            
           await dbContext.SaveChangesAsync();
        }      
        

        public void Update (T entity)
        {
            dbContext.Update(entity);
        }
    }
}
