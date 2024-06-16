using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
    public class OrderDetailUpdateDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

        public Guid PaymentId { get; set; }



    }
}
