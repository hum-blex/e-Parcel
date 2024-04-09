using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs
{
	public class CategoryDto
	{
		public Guid Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; } = null!;

		public int DisplayOrder { get; set; }

		public string? Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime? ModifiedOn { get; set; }

		public DateTime? DeletedOn { get; set; }

		[StringLength(50)]
		public string? ModifiedBy { get; set; }

		public bool? IsDeleted { get; set; }

	}
}
