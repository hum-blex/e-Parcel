using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class ShoppingSessionRepository : Repository<ShoppingSession>, IShoppingSessionRepository
{
	private ApplicationDbContext _db;
	public ShoppingSessionRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(ShoppingSession obj)
	{
		_db.ShoppingSessions.Update(obj);
	}
}
