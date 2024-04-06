using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IDiscountRepository : IRepository<Discount>
{
	void Update(Discount obj);

	void UpdateDelete(int id);
}
