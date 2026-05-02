using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Mkw.Domain.Entities;
using Mkw.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MkwContext _context;
        private Dictionary<string, IBaseRepository> _repository;

        public UnitOfWork(MkwContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
        public async Task Insert<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity
        {
            var conn = _context.Database.GetDbConnection();

            // 2. 檢查目前是否有開啟 EF 交易 (雖然你現在沒用，但寫著是好習慣)
            var trans = _context.Database.CurrentTransaction?.GetDbTransaction();

            // 3. 呼叫 Dapper.Contrib 的擴充方法
            // 它會自動去讀 TEntity 的名稱來找 Table
            await conn.InsertAsync<TEntity>(entity, trans, commandTimeout);
        }

        public Task Update<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task Delete<TEntity>(TEntity entity, int? commandTimeout = null) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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
    }
}
