using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Entities;

public partial class User
{
    [Key]
    [Column("UserID")]
    [StringLength(50)]
    [Unicode(false)]
    public string UserId { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("AddressID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddressId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Users")]
    public virtual Address? Address { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
