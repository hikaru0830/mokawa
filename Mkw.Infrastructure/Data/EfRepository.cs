using Mkw.Domain.Entities;
using Mkw.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Infrastructure.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
