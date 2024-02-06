using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Entities;

public partial class Product
{
    [Key]
    [Column("ProductID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductId { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    [Column("CategoryID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CategoryId { get; set; }

    [Column("ImageURL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
