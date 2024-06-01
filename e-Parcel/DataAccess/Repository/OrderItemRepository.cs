using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
	private ApplicationDbContext _db;
	public OrderItemRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public async Task<OrderItem> UpdateAsync(Guid id, OrderItem obj)
	{
		var existingOrderItem = await _db.OrderItems.FindAsync(id);
		if (existingOrderItem == null) return null;

		existingOrderItem.OrderId = obj.OrderId;
		existingOrderItem.ModifiedOn = DateTime.Now;
		existingOrderItem.Quantity = obj.Quantity;
		existingOrderItem.ProductId = obj.ProductId;

		return existingOrderItem;
	}
}
