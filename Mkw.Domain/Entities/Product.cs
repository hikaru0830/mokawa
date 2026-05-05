using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mkw.Domain.Entities;

namespace Mkw.Domain.Entities;

[Table("products")]
public partial class Product : BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; } = null!;

    [Column("product_code")]
    public string ProductCode { get; set; } = null!;

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("unit_price")]
    public decimal UnitPrice { get; set; }

    [Column("create_at")]
    public DateTime CreateAt { get; set; }

    [Column("creator_id")]
    public Guid CreatorId { get; set; }

    [Column("is_remove")]
    public bool? IsRemove { get; set; }
}
