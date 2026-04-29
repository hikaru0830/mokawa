using Mkw.Domain.Entities;
using Mkw.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mkw.Infrastructure.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<TId>(TId id) where TId : struct
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync<TId>(TId id) where TId : struct
        {
            throw new NotImplementedException();
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
