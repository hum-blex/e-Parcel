using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

[Table("CartItem")]
public partial class CartItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int SessionId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("CartItems")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SessionId")]
    [InverseProperty("CartItems")]
    public virtual ShoppingSession Session { get; set; } = null!;
}
