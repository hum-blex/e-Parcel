using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.ShoppingSessions
{
    public class ShoppingSessionUpdateDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }
    }
}
