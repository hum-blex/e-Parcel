using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
{
	private ApplicationDbContext _db;
	public UserAddressRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(UserAddress obj)
	{
		_db.UserAddresses.Update(obj);
	}
}
