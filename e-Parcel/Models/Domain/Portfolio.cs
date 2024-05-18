namespace e_Parcel.Models.Domain
{
	public class Portfolio
	{
		public string AppUserId { get; set; }
		public Guid OrderItemId { get; set; }
		public AppUser AppUser { get; set; }
		public OrderItem OrderItem { get; set; }
	}
}
