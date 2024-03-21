using e_Parcel.DataAccess.Repository.IRepository;

namespace e_Parcel.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
	private ApplicationDbContext _db;
	public ICategoryRepository Category { get; private set; }
	public IProductInventoryRepository ProductInventory { get; private set; }
	public UnitOfWork(ApplicationDbContext db)
	{
		_db = db;
		Category = new CategoryRepository(_db);
		ProductInventory = new ProductInventoryRepository(_db);
	}



	public void Save()
	{
		_db.SaveChanges();
	}
}
