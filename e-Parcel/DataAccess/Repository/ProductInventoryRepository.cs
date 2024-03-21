using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository
{
	public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
	{
		private ApplicationDbContext _db;
		public ProductInventoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(ProductInventory obj)
		{
			_db.ProductInventories.Update(obj);
		}
	}
}
