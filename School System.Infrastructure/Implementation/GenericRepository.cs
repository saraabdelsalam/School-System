using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using School_System.Infrastructure.Interfaces;
using School_System.Infrastructure.Context;
using System.Linq.Expressions;
using School_System.Data.Common;

namespace School_System.Infrastructure.Implementation
{
    public class GenericRepository<T, Tid> : IGenericRepository<T, Tid> where T : BaseEntity<Tid>
    {
        #region Vars / Props

        protected readonly AppDbContext _dbContext;

        #endregion

        #region Constructor(s)
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods

        #endregion

        #region Actions
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool disableTracking = true, bool includeSoftDeleted = false)
        {
            if (disableTracking)
                return includeSoftDeleted ? _dbContext.Set<T>().AsNoTracking().Where(predicate).IgnoreQueryFilters() : _dbContext.Set<T>().AsNoTracking().Where(predicate);

            return includeSoftDeleted ? _dbContext.Set<T>().IgnoreQueryFilters().Where(predicate) : _dbContext.Set<T>().Where(predicate);
        }
        public async Task<T> GetByIdAsync(Tid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(i => i.Id.Equals(id));

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public IDbContextTransaction BeginTransaction()
        {


            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();

        }
        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }
        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>().AsQueryable();

        }

        public virtual async Task<IQueryable<T>> GetAllAsync()
        {

            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
        #endregion
    }
}
