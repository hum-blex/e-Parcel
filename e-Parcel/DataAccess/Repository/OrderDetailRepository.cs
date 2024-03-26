using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		private ApplicationDbContext _db;
		public OrderDetailRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(OrderDetail obj)
		{
			var existingOrder = _db.OrderDetails.FirstOrDefault(x => x.Id == obj.Id);

			existingOrder.UserId = obj.UserId;
			existingOrder.PaymentDetails = obj.PaymentDetails;
			existingOrder.PaymentId = obj.PaymentId;

			_db.OrderDetails.Update(obj);
		}
	}
}
