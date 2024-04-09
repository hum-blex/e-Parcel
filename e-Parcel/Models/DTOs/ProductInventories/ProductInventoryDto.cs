using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs.ProductInventories
{
    public class ProductInventoryDto
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string? ModifiedBy { get; set; }
    }
}
