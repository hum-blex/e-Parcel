using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	private ApplicationDbContext _db;
	public CategoryRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}


	public void Update(int id, Category obj)
	{
		var existingCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
		

		existingCategory.Name = obj.Name;
		existingCategory.Description = obj.Description;
		existingCategory.DisplayOrder = obj.DisplayOrder;

		_db.Categories.Update(existingCategory);
	}


    public void UpdateDelete(int id)
	{
		var existingCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
        

		existingCategory.IsDeleted = true;


        _db.Categories.Update(existingCategory);
    }
}
