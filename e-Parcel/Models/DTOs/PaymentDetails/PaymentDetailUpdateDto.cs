using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.PaymentDetails
{
    public class PaymentDetailUpdateDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = null!;


        [StringLength(50)]
        public string Provider { get; set; } = null!;

    }
}
