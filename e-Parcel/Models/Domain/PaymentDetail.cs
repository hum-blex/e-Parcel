using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_Parcel.Models.Domain;

public partial class PaymentDetail
{

	public Guid Id { get; set; }

	public Guid OrderId { get; set; }
	[Column(TypeName = "decimal(18, 0)")]
	public decimal Amount { get; set; }

	[StringLength(50)]
	public string Status { get; set; } = null!;

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }

	[StringLength(50)]
	public string Provider { get; set; } = null!;

	[JsonIgnore]
	[ForeignKey("OrderId")]
	public OrderDetail Order { get; set; } = null!;

}
