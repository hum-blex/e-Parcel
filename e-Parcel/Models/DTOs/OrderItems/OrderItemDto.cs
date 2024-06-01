using e_Parcel.Models.Domain;

namespace e_Parcel.Models.DTOs.OrderItems
{
	public class OrderItemDto
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public int Quantity { get; set; }
		public Guid ProductId { get; set; }
		public DateTime CreatedOn { get; set; }

		public DateTime? ModifiedOn { get; set; }
		public OrderDetail Order { get; set; }
		public Product Product { get; set; }
	}
}
