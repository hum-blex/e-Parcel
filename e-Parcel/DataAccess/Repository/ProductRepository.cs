using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private ApplicationDbContext _db;
	public ProductRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(Product obj)
	{
		_db.Products.Update(obj);
	}
}
