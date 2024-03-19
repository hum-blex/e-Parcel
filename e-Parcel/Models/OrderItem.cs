﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

[Keyless]
public partial class OrderItem
{
    [Column("id")]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [ForeignKey("OrderId")]
    public virtual OrderDetail Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;
}
