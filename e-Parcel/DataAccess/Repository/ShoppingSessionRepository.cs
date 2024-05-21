using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class ShoppingSessionRepository : Repository<ShoppingSession>, IShoppingSessionRepository
{
	private ApplicationDbContext _db;
	public ShoppingSessionRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

    public async Task<ShoppingSession> UpdateAsync(Guid id, ShoppingSession obj)
    {
        var existingShoppingSess = await _db.ShoppingSessions.FindAsync(id);
		if (existingShoppingSess == null) return null;

		existingShoppingSess.ModifiedOn = DateTime.Now;
		existingShoppingSess.UserId = obj.UserId;
		existingShoppingSess.Total = obj.Total;

		return existingShoppingSess;
    }
}
