using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Mkw.Domain.Entities;
using Mkw.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using static Dapper.SqlMapper;

namespace Mkw.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MkwContext _context;
        private Dictionary<string, IBaseRepository> _repository = new();
        private bool _disposed = false;
        private DbConnection _connection;

        public UnitOfWork(MkwContext context)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
        public async Task Insert<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            //var conn = _context.Database.GetDbConnection();
            //var trans = _context.Database.CurrentTransaction?.GetDbTransaction();
            //await conn.InsertAsync<TEntity>(entity, statement =>
            //{
            //    if (trans != null)
            //    {
            //        statement.AttachToTransaction(trans);
            //    }

            //    if (commandTimeoutSecond != null)
            //    {
            //        statement.WithTimeout(TimeSpan.FromSeconds(commandTimeoutSecond.Value));
            //    }
            //});
            await RunDapperTask<TEntity>(
                commandTimeoutSecond,
                async (statement) =>
                {
                    await _connection.InsertAsync<TEntity>(entity, statement);
                });
        }

        public async Task PatchUpdate<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            await RunDapperTask<TEntity>(
                commandTimeoutSecond,
                async (statement) =>
                {
                    await _connection.UpdateAsync<TEntity>(entity, statement);
                });
        }

        public async Task ReplaceUpdate<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            await RunDapperTask<TEntity>(
                commandTimeoutSecond,
                async (statement) =>
                {
                    await _connection.UpdateAsync<TEntity>(entity, statement);
                });
        }

        /// <summary>
        /// Delete by primary key(s)
        /// </summary>
        /// <returns></returns>
        public async Task Delete<TEntity>(TEntity entity, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            await RunDapperTask<TEntity>(
                commandTimeoutSecond,
                async (statement) =>
                {
                    await _connection.DeleteAsync<TEntity>(entity, statement);
                });
        }

        public async Task<TEntity> Find<TEntity>(string sqlString, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            return await _connection.QuerySingleOrDefaultAsync<TEntity>(sqlString);
        }

        public Task<IEnumerable<TEntity>> Where<TEntity>(string sqlString, int? commandTimeoutSecond = null) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<TValue> ExecuteScalar<TValue>(string sqlString, int? commandTimeoutSecond = null)
        {
            throw new NotImplementedException();
        }

        public Task Execute(string sqlString, int? commandTimeoutSecond = null)
        {
            throw new NotImplementedException();
        }

        public Task RunTransaction(Func<Task> action)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // 核心重點：叫 Context 釋放資源、關閉連線
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }

        private async Task RunDapperTask<TEntity>(int? commandTimeoutSecond, Func<Action<IStandardSqlStatementOptionsBuilder<TEntity>>, Task> callback) where TEntity : BaseEntity
        {
            var trans = _context.Database.CurrentTransaction?.GetDbTransaction();
            await callback(statement =>
            {
                if (trans != null)
                {
                    statement.AttachToTransaction(trans);
                }

                if (commandTimeoutSecond != null)
                {
                    statement.WithTimeout(TimeSpan.FromSeconds(commandTimeoutSecond.Value));
                }
            });
        }
    }
}
