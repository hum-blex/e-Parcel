using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs.CartItems
{
    public class CartItemUpdateDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid SessionId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
