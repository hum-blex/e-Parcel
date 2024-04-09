using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class CartItem
{
	public Guid Id { get; set; }

	public Guid SessionId { get; set; }

	public Guid ProductId { get; set; }

	public int? Quantity { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }

	// Navigation properties

	[ForeignKey("ProductId")]
	[ValidateNever]
	public Product Product { get; set; } = null!;

	[ForeignKey("SessionId")]
	[ValidateNever]
	public ShoppingSession Session { get; set; } = null!;
}
