using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.OrderDetails
{
    public class OrderDetailAddDto
    {

        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

        public Guid PaymentId { get; set; }


    }
}
