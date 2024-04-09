using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class OrderDetail
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public Guid PaymentId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }


    [ForeignKey("UserId")]
    [ValidateNever]
    public UserLogin User { get; set; } = null!;
}
