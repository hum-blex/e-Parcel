using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

[Table("UserLogin")]
public partial class UserLogin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LoginTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LogoutTime { get; set; }

    public bool? IsDisabled { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Role { get; set; } = null!;

    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("User")]
    public virtual ICollection<ShoppingSession> ShoppingSessions { get; set; } = new List<ShoppingSession>();

    [InverseProperty("User")]
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

    [InverseProperty("User")]
    public virtual ICollection<UserPayment> UserPayments { get; set; } = new List<UserPayment>();
}
