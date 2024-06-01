using e_Parcel.Models.DTOs.OrderItems;
using e_Parcel.Models.DTOs.PaymentDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
	public class OrderDetailAddDto
	{

		public Guid UserId { get; set; }

		[Column(TypeName = "decimal(18, 0)")]
		public decimal Total { get; set; }
		public PaymentDetailAddDto Payment { get; set; }
		public List<OrderItemAddDto> OrderItems { get; set; }

	}
}
