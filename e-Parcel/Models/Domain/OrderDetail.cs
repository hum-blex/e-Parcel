using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public partial class OrderDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public int PaymentId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    [ForeignKey("UserId")]
    [InverseProperty("OrderDetails")]
    [ValidateNever]
    public virtual UserLogin User { get; set; } = null!;
}
