using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

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

    // Navigation properties

    [ForeignKey("OrderId")]
    public virtual OrderDetail Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;
}
