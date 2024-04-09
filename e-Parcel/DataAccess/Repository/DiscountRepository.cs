using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class DiscountRepository : Repository<Discount>, IDiscountRepository
{
	private ApplicationDbContext _db;
	public DiscountRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

	public void Update(Discount obj)
	{

		_db.Discounts.Update(obj);
	}

}
