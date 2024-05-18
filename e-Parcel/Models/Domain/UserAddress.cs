using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class UserAddress
{
	public Guid Id { get; set; }

	public string UserId { get; set; }

	public string Address { get; set; } = null!;

	[StringLength(50)]
	public string City { get; set; } = null!;

	[StringLength(20)]
	public string? Country { get; set; }

	[StringLength(50)]
	public string? Telephone { get; set; }

	[StringLength(50)]
	public string Mobile { get; set; } = null!;

	[StringLength(50)]
	public string State { get; set; } = null!;

	[StringLength(50)]
	public string? PostalCode { get; set; }

	[ForeignKey("UserId")]
	public AppUser User { get; set; } = null!;
}
