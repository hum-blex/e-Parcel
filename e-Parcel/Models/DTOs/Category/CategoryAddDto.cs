using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs
{
	public class CategoryAddDto
	{

		[StringLength(50)]
		public string Name { get; set; } = null!;

		public int DisplayOrder { get; set; }

		public string? Description { get; set; }

	}
}
