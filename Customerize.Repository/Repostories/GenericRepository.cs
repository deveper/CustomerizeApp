using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customerize.Repository.Repostories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id, int? id_2)
        {
            return await _dbset.FindAsync(id, id_2);
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}
