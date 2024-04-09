
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs
{
	public class DiscountDto
	{
		[Key]

		public int Id { get; set; }

		[Column(TypeName = "decimal(18, 0)")]
		public decimal? DiscountPercentage { get; set; }

		public bool? Active { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime CreatedOn { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? ModifiedOn { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DeletedOn { get; set; }

		[StringLength(50)]
		[Unicode(false)]
		public string Name { get; set; } = null!;

		[Unicode(false)]
		public string? Description { get; set; }

		[StringLength(50)]
		[Unicode(false)]
		public string? ModifiedBy { get; set; }

		public bool? IsDeleted { get; set; }
	}
}
