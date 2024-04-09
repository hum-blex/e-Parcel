using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

[Table("UserPayment")]
public partial class UserPayment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PaymentType { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Provider { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserPayments")]
    public virtual UserLogin User { get; set; } = null!;
}
