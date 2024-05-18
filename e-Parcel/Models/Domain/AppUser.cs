using Microsoft.AspNetCore.Identity;

namespace e_Parcel.Models.Domain
{
	public class AppUser : IdentityUser
	{
		public DateTime CreatedOn { get; set; }

		public DateTime? LastLogin { get; set; }

		public DateTime? LogoutTime { get; set; }

		public bool? IsDisabled { get; set; }
		public UserAddress Address { get; set; }

		public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
	}
}

