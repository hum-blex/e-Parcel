using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.OrderItems;
using e_Parcel.Models.DTOs.PaymentDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
	public class OrderDetailDto
	{
		public string UserId { get; set; }
		public string Encrypted { get; set; }

		[Column(TypeName = "decimal(18, 0)")]
		public decimal Total { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }


		public AppUser User { get; set; }
		public PaymentDetailDto Payment { get; set; }
		public List<OrderItemDto> OrderItems { get; set; }
	}
}
