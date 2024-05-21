using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IDiscountRepository : IRepository<Discount>
{
	Task<Discount?> UpdateAsync(Guid id, Discount obj);

}
