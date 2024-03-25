using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository
{
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

		public void UpdateDelete(int id)
		{
			var objFromDb = _db.Discounts.FirstOrDefault(c => c.Id == id);
			if (objFromDb != null) objFromDb.IsDeleted = true;



		}
	}
}
