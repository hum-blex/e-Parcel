using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class Product
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	public string Description { get; set; } = null!;

	[Column(TypeName = "decimal(18, 0)")]
	public decimal Price { get; set; }

	public Guid CategoryId { get; set; }

	[Unicode(false)]
	public string ImageUrl { get; set; } = null!;

	public Guid DiscountId { get; set; }

	public Guid InventoryId { get; set; }

	public DateTime? CreatedOn { get; set; }

	[StringLength(50)]
	public string? ModifiedBy { get; set; }

	public string Sku { get; set; } = null!;

	public DateTime? ModifiedOn { get; set; }


	[ForeignKey("CategoryId")]
	[ValidateNever]
	public Category Category { get; set; } = null!;

	[ForeignKey("DiscountId")]
	[ValidateNever]
	public Discount Discount { get; set; } = null!;

	[ForeignKey("InventoryId")]
	[ValidateNever]
	public ProductInventory Inventory { get; set; } = null!;
	public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
