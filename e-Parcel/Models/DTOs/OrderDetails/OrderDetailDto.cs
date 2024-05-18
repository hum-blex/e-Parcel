using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.PaymentDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
	public class OrderDetailDto
	{
		public Guid Id { get; set; }
		public string Encrypted { get; set; }

		[Column(TypeName = "decimal(18, 0)")]
		public decimal Total { get; set; }

		public DateTime CreatedOn { get; set; }
		public AppUser User { get; set; }
		public PaymentDetailDto Payment { get; set; }
	}
}
