using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs.CartItems
{
    public class CartItemAddDto
    {
        [Required]
        public Guid SessionId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
