using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
	private ApplicationDbContext _db;
	public OrderItemRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(OrderItem obj)
	{
		_db.OrderItems.Update(obj);
	}
}
