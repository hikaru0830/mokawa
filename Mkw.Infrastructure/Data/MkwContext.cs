using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mkw.Domain.Entities;

namespace Mkw.Infrastructure.Data;

public partial class MkwContext : DbContext
{
    public MkwContext()
    {
    }

    public MkwContext(DbContextOptions<MkwContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:MokawaDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
