using Mkw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Entity Framwork
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        // Dapper
        Task Insert<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity;
        Task Update<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity;
        Task Delete<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity;

        // 存檔與交易控制
        Task<int> SaveChangesAsync();
        Task RunTransaction(Func<Task> action);
    }
}
