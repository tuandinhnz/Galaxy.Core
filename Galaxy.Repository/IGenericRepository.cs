using System.Linq.Expressions;
using Galaxy.Paging;

namespace Galaxy.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> GetById(Guid id);
        Task<IList<T>> GetAll(Paginator paginator);
        Task<IList<T>> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
