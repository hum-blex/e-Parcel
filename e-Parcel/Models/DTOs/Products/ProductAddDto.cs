using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.Products
{
    public class ProductAddDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        [Unicode(false)]
        public string ImageUrl { get; set; } = null!;

        public Guid DiscountId { get; set; }

        public Guid InventoryId { get; set; }

        public string Sku { get; set; } = null!;



    }
}
