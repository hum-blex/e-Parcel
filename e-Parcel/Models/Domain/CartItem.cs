using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

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

	// Navigation properties

	[ForeignKey("ProductId")]
	[InverseProperty("CartItems")]
	[ValidateNever]
	public virtual Product Product { get; set; } = null!;

	[ForeignKey("SessionId")]
	[InverseProperty("CartItems")]
	[ValidateNever]
	public virtual ShoppingSession Session { get; set; } = null!;
}
