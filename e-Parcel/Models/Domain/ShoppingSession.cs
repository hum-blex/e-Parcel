using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class ShoppingSession
{
	public Guid Id { get; set; }

	public string UserId { get; set; }

	[Column(TypeName = "decimal(18, 0)")]
	public decimal Total { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }


	[ForeignKey("UserId")]
	public AppUser User { get; set; } = null!;
}
