using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
	Task<Category> UpdateAsync(Guid id, Category obj);



}
