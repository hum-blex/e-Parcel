using e_Parcel.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

        public DateTime CreatedOn { get; set; }
        public UserLogin User { get; set; }
        public PaymentDetail Payment { get; set; }
    }
}
