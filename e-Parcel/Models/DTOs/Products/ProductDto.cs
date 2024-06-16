using e_Parcel.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }

        [Unicode(false)]
        public string ImageUrl { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string? ModifiedBy { get; set; }

        public string Sku { get; set; } = null!;

        public DateTime? ModifiedOn { get; set; }
        public Category Category { get; set; }

        public Discount Discount { get; set; }

        public ProductInventory Inventory { get; set; }
    }
}
