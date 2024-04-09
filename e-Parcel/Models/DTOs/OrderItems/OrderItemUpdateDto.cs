namespace e_Parcel.Models.DTOs.OrderItems
{
    public class OrderItemUpdateDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
    }
}
