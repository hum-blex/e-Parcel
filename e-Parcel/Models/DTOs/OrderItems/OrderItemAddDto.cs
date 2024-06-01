namespace e_Parcel.Models.DTOs.OrderItems
{
	public class OrderItemAddDto
	{
		public Guid OrderId { get; set; }
		public int Quantity { get; set; }

		public Guid ProductId { get; set; }
	}
}
