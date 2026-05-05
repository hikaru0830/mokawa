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
        Task Insert<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task PatchUpdate<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task ReplaceUpdate<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task Delete<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task<TEntity> Find<TEntity>(string sqlString, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task<IEnumerable<TEntity>> Where<TEntity>(string sqlString, int? commandTimeoutSecond = null) where TEntity : BaseEntity;
        Task<TValue> ExecuteScalar<TValue>(string sqlString, int? commandTimeoutSecond = null);
        Task Execute(string sqlString, int? commandTimeoutSecond = null);

        // 存檔與交易控制
        Task<int> SaveChangesAsync();
        Task RunTransaction(Func<Task> action);
    }
}
