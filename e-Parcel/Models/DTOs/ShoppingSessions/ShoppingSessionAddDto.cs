using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.ShoppingSessions
{
    public class ShoppingSessionAddDto
    {

        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

    }
}
