using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.DTOs
{
	public class ProductInventoryUpdateDto
	{
		public Guid Id { get; set; }

		public int Quantity { get; set; }


	}
}
