using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.DataAccess.Repository
{
	public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
	{
		private ApplicationDbContext _db;
		public ProductInventoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		
		public void Update(int id, ProductInventory obj)
		{
			var existingInventory = _db.ProductInventories.FirstOrDefault(c => c.Id == id);

			existingInventory.Quantity = obj.Quantity;
			existingInventory.ModifiedBy = obj.ModifiedBy;

			_db.ProductInventories.Update(existingInventory);
		}
	}
}
