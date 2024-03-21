using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
{
	private ApplicationDbContext _db;
	public PaymentDetailRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(PaymentDetail obj)
	{
		_db.PaymentDetails.Update(obj);
	}
}
