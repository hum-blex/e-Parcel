using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models;

public partial class Product
{
	[Key]
	public int Id { get; set; }

	[Unicode(false)]
	public string Name { get; set; } = null!;

	[Unicode(false)]
	public string Description { get; set; } = null!;

	[Column(TypeName = "decimal(18, 0)")]
	public decimal Price { get; set; }

	public int CategoryId { get; set; }

	[Unicode(false)]
	public string? ImageUrl { get; set; } = null!;

	public int DiscountId { get; set; }

	public int InventoryId { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? CreatedOn { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DeletedOn { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string? ModifiedBy { get; set; }

	[Column("SKU")]
	[StringLength(50)]
	[Unicode(false)]
	public string Sku { get; set; } = null!;

	[Column(TypeName = "datetime")]
	public DateTime? ModifiedOn { get; set; }

	[InverseProperty("Product")]
	public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

	[ForeignKey("CategoryId")]
	[InverseProperty("Products")]

	public virtual Category Category { get; set; } = null!;

	[ForeignKey("DiscountId")]
	[InverseProperty("Products")]
	[ValidateNever]

	public virtual Discount Discount { get; set; } = null!;

	[ForeignKey("InventoryId")]
	[InverseProperty("Products")]
	public virtual ProductInventory Inventory { get; set; } = null!;
}
