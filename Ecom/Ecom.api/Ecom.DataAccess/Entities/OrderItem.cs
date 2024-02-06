using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Entities;

public partial class OrderItem
{
    [Key]
    [Column("OrderItemID")]
    [StringLength(50)]
    [Unicode(false)]
    public string OrderItemId { get; set; } = null!;

    [Column("OrderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OrderId { get; set; }

    [Column("ProductID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Subtotal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order? Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product? Product { get; set; }
}
