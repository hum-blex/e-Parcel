using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class UserPaymentRepository : Repository<UserPayment>, IUserPaymentRepository
{
	private ApplicationDbContext _db;
	public UserPaymentRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(UserPayment obj)
	{
		_db.UserPayments.Update(obj);
	}
}
