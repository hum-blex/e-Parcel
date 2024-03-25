using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	private ApplicationDbContext _db;
	public CategoryRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}


	public void Update(Category obj)
	{
		_db.Categories.Update(obj);
	}

	public void UpdateDelete(Category obj)
	{
		var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == obj.Id);
		if (objFromDb != null)
		{
			obj.IsDeleted = true;
		}
	}


}
