using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
	void Update(int id, Category obj);

	void UpdateDelete(int id);


}
