using Mkw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mkw.Domain.Interfaces
{
    public interface IRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        TEntity GetById<TId>(TId id) where TId : struct;
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        //List<TEntity> List();
    }
}
