using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private ApplicationDbContext _db;
	public ProductRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

    public async Task<Product> UpdateAsync(Guid id, Product obj)
    {
        var existingProduct = await _db.Products.FindAsync(id);
		if (existingProduct == null) return null;

		existingProduct.Name = obj.Name;
		existingProduct.Description = obj.Description;
		existingProduct.Price = obj.Price;
		existingProduct.ModifiedBy = obj.ModifiedBy;
		existingProduct.ModifiedOn = DateTime.Now;
		existingProduct.Sku = obj.Sku;
		existingProduct.DiscountId = obj.DiscountId;
		existingProduct.InventoryId = obj.InventoryId;
		existingProduct.CategoryId = obj.CategoryId;
		existingProduct.ImageUrl = obj.ImageUrl;

		return existingProduct;
    }
}
