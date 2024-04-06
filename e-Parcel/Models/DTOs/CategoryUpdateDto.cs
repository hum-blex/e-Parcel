﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs
{
	public class CategoryUpdateDto
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Unicode(false)]
		public string Name { get; set; } = null!;

		public int DisplayOrder { get; set; }

		[Unicode(false)]
		public string? Description { get; set; }
	}
}
