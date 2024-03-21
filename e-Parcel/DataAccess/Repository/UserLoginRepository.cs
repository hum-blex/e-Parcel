using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
	private ApplicationDbContext _db;
	public UserLoginRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(UserLogin obj)
	{
		_db.UserLogins.Update(obj);
	}
}
