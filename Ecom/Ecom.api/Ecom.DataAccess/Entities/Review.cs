using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Entities;

public partial class Review
{
    [Key]
    [Column("ReviewID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ReviewId { get; set; } = null!;

    [Column("ProductID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    [Column("UserID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserId { get; set; }

    public int? Rating { get; set; }

    [Column(TypeName = "text")]
    public string? Comment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User? User { get; set; }
}
