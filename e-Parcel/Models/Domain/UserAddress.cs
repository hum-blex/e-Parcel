using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

[Table("UserAddress")]
public partial class UserAddress
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Country { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Telephone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Mobile { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserAddresses")]
    public virtual UserLogin User { get; set; } = null!;
}
