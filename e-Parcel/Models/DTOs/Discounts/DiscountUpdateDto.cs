using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs.Discounts
{
    public class DiscountUpdateDto
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? DiscountPercentage { get; set; }

        public bool? Active { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? IsDeleted { get; set; } = false;
    }
}
