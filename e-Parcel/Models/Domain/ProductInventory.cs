using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models.Domain;

[Table("ProductInventory")]
public partial class ProductInventory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [InverseProperty("Inventory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
