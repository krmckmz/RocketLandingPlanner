using Microsoft.EntityFrameworkCore;
using RocketLandingPlanner.Data.Contexts;
using RocketLandingPlanner.Data.Repositories.Base.Abstract;
using System.Linq.Expressions;

namespace RocketLandingPlanner.Data.Repositories.Base.Concrete
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly RocketLandingDbContext _dbContext;

        public BaseRepository(RocketLandingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().AsQueryable().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalCount()
        {
            var count = await _dbContext.Set<T>().AsQueryable().CountAsync();

            return count;
        }
        public async Task<T> GetItemAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }
    }
}
