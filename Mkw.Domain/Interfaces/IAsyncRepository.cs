using Mkw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mkw.Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetByIdAsync<TId>(TId id) where TId : struct;
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        //Task<List<TEntity>> ListAsync();
    }
}
