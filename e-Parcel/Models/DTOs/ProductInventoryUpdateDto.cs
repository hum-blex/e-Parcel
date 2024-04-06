using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs
{
	public class ProductInventoryUpdateDto
	{
		[Key]

		public int Id { get; set; }

		public int Quantity { get; set; }


	}
}
