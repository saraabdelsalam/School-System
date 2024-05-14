using Microsoft.EntityFrameworkCore.Storage;
using School_System.Data.Common;
using System.Linq.Expressions;


namespace School_System.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, Tid> where T : BaseEntity<Tid> where Tid : notnull
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool disableTracking = true, bool includeSoftDeleted = false);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Tid id, bool disableTracking = true, params Expression<Func<T, object>>[] includes);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
    }

}
