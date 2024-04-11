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


    public async Task<Discount?> UpdateAsync(Guid id, Discount obj)
    {
        var existingDiscount = await _db.Discounts.FindAsync(id);
		if (existingDiscount == null) return null;

		existingDiscount.Name = obj.Name;
		existingDiscount.Description = obj.Description;
		existingDiscount.DiscountPercentage = obj.DiscountPercentage;
		existingDiscount.ModifiedBy = obj.ModifiedBy;
		existingDiscount.ModifiedOn = DateTime.Now;
		existingDiscount.Active = obj.Active;

		return existingDiscount;
    }
}
