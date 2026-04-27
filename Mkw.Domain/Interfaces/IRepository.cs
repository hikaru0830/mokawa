using Mkw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Domain.Interfaces
{
    public interface IRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
