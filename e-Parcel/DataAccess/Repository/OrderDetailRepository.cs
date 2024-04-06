using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
	private ApplicationDbContext _db;
	public OrderDetailRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(OrderDetail obj)
	{
		_db.OrderDetails.Update(obj);
	}
}
