using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_Parcel.Models.Domain;

public class OrderItem
{
	public Guid Id { get; set; }

	public Guid OrderId { get; set; }

	public int Quantity { get; set; }

	public Guid ProductId { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }

	// Navigation properties
	[JsonIgnore]
	[ForeignKey("OrderId")]
	public OrderDetail Order { get; set; } = null!;
	[JsonIgnore]
	[ForeignKey("ProductId")]
	public Product Product { get; set; } = null!;
	public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

}
