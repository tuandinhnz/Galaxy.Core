using System.Linq.Expressions;
using Galaxy.Paging;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll(Paginator paginator)
        {
            int offset = paginator.PageNumber * paginator.Limit;
            int limit = paginator.Limit;
            
            return await _context.Set<T>()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public Task<IList<T>> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
