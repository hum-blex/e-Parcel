using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

public partial class PaymentDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int OrderId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Provider { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("PaymentDetails")]
    public virtual OrderDetail Order { get; set; } = null!;
}
