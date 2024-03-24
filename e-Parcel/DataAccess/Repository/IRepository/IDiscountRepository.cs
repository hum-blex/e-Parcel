using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IDiscountRepository : IRepository<Discount>
{
	void Update(int id, Discount obj);

	void UpdateDelete(int id);
}
