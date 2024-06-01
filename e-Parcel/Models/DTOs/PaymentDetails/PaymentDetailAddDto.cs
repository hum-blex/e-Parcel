using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.PaymentDetails
{
	public class PaymentDetailAddDto
	{
		[Required]
		public Guid OrderId { get; set; }
		[Required]

		[Column(TypeName = "decimal(18, 0)")]
		public decimal Amount { get; set; }

		[StringLength(50)]
		public string Status { get; set; } = null!;
		[Required]


		[StringLength(50)]
		public string Provider { get; set; } = null!;
	}
}
