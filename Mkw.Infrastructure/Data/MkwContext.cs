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

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:MokawaDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreatorId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("creator_id");
            entity.Property(e => e.IsRemove).HasColumnName("is_remove");
            entity.Property(e => e.ProductCode).HasColumnName("product_code");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
