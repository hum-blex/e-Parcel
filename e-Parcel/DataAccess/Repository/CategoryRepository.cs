using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	private ApplicationDbContext _db;
	public CategoryRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}


	public async Task<Category> UpdateAsync(Guid id, Category obj)
	{
		var existing = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
		if (existing == null) return null;
		existing.Name = obj.Name;
		existing.Description = obj.Description;
		existing.DisplayOrder = obj.DisplayOrder;
		existing.ModifiedOn = DateTime.Now;
		existing.IsDeleted = obj.IsDeleted;
		return existing;
	}


}
