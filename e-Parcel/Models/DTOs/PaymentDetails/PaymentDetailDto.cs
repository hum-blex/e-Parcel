using e_Parcel.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.PaymentDetails
{
    public class PaymentDetailDto
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string Provider { get; set; } = null!;

        public OrderDetail Order { get; set; } = null!;
    }
}
