using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs
{
	public class CategoryDto
	{
		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		[Unicode(false)]
		public string Name { get; set; } = null!;

		public int DisplayOrder { get; set; }

		[Unicode(false)]
		public string? Description { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime CreatedOn { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? ModifiedOn { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DeletedOn { get; set; }

		[StringLength(50)]
		[Unicode(false)]
		public string? ModifiedBy { get; set; }

		public bool? IsDeleted { get; set; }

	}
}
