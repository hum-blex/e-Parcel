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

	public async Task<OrderDetail> UpdateAsync(Guid id, OrderDetail obj)
	{
		var exisitngOrderDetail = await _db.OrderDetails.FindAsync(id);
		if (exisitngOrderDetail == null) return null;

		exisitngOrderDetail.Total = obj.Total;
		exisitngOrderDetail.ModifiedOn = DateTime.Now;

		return exisitngOrderDetail;
	}
}
