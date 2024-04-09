using e_Parcel.Models.Domain;

namespace e_Parcel.Models.DTOs.CartItems
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public ShoppingSession Session { get; set; }
    }
}
