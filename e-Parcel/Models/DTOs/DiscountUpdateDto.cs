using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs
{
	public class DiscountUpdateDto
	{
		[Key]

		public int Id { get; set; }

		[Column(TypeName = "decimal(18, 0)")]
		public decimal? DiscountPercentage { get; set; }

		public bool? Active { get; set; }

		[Column(TypeName = "datetime")]


		[StringLength(50)]
		[Unicode(false)]
		public string Name { get; set; } = null!;

		[Unicode(false)]
		public string? Description { get; set; }


		public bool? IsDeleted { get; set; }
	}
}
