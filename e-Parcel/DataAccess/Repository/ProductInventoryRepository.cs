using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.DataAccess.Repository;

public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
{
	private ApplicationDbContext _db;
	public ProductInventoryRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}



	public async Task<ProductInventory> UpdateAsync(Guid id, ProductInventory obj)
	{
		var existing = await _db.ProductInventories.FirstOrDefaultAsync(c => c.Id == id);
		if (existing == null) return null;
		existing.Quantity = obj.Quantity;
		existing.ModifiedOn = DateTime.Now;

		return existing;

	}
}
