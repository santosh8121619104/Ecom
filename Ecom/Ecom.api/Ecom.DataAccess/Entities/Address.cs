using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Entities;

public partial class Address
{
    [Key]
    [Column("AddressID")]
    [StringLength(50)]
    [Unicode(false)]
    public string AddressId { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Street { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? State { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Country { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
