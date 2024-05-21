using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs.Categories
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public int DisplayOrder { get; set; }

        public string? Description { get; set; }

        public bool? IsDeleted { get; set; } = false;
    }
}
