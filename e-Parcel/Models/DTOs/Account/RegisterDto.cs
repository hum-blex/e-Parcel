using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs.Account
{
	public class RegisterDto
	{
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email format")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

		[Required(ErrorMessage = "City is required")]
		[StringLength(50, ErrorMessage = "City must be less than 50 characters")]
		public string City { get; set; }

		[StringLength(20, ErrorMessage = "Country must be less than 20 characters")]
		public string? Country { get; set; }

		[StringLength(50, ErrorMessage = "Telephone must be less than 50 characters")]
		public string? Telephone { get; set; }

		[Required(ErrorMessage = "Mobile is required")]
		[StringLength(50, ErrorMessage = "Mobile must be less than 50 characters")]
		public string Mobile { get; set; }

		[Required(ErrorMessage = "State is required")]
		[StringLength(50, ErrorMessage = "State must be less than 50 characters")]
		public string State { get; set; }

		[StringLength(50, ErrorMessage = "PostalCode must be less than 50 characters")]
		public string? PostalCode { get; set; }
	}
}
