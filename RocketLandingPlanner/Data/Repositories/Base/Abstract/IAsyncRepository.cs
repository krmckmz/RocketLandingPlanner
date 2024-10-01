using System.Linq.Expressions;

namespace RocketLandingPlanner.Data.Repositories.Base.Abstract
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetTotalCount();
        Task<T> GetItemAsync(Expression<Func<T, bool>> filter = null);
    }
}
