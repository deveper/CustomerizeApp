using Common.Dtos;
using System.Linq.Expressions;

namespace Customerize.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<ResultDto<T>> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IQueryable<T>> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> WhereList(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<ResultDto<T>> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<ResultDto<T>> UpdateAsync(T entity);
        Task<ResultDto<T>> RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
