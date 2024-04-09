using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.DTOs
{
	public class ProductInventoryDto
	{
		public Guid Id { get; set; }

		public int Quantity { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime? ModifiedOn { get; set; }

		[StringLength(50)]
		public string? ModifiedBy { get; set; }
	}
}
