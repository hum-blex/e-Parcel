using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class OrderDetail
{
	public Guid Id { get; set; }

	public string UserId { get; set; }
	public string Encrypted { get; set; }

	[Column(TypeName = "decimal(18, 0)")]
	public decimal Total { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }


	[ForeignKey("UserId")]
	[ValidateNever]
	public AppUser User { get; set; } = null!;

	[ForeignKey("OrderId")]
	public PaymentDetail Payment { get; set; } = null!;
}
