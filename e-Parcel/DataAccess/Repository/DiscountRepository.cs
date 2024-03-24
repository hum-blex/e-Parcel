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

		public void Update(int id, Discount obj)
		{
			var existingDiscount = _db.Discounts.FirstOrDefault(c => c.Id == id);

			existingDiscount.DiscountPercentage = obj.DiscountPercentage;
			existingDiscount.Active = obj.Active;
			existingDiscount.Name = obj.Name;
			existingDiscount.Description = obj.Description;
			existingDiscount.ModifiedBy = obj.ModifiedBy;

			_db.Discounts.Update(existingDiscount);
		}

		public void UpdateDelete(int id) 
		{
            var existingDiscount = _db.Discounts.FirstOrDefault(c => c.Id == id);

			existingDiscount.IsDeleted = true;

			_db.Discounts.Update(existingDiscount);
        }
	}
}
