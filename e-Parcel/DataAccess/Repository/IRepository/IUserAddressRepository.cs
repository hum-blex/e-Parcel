using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUserAddressRepository : IRepository<UserAddress>
{
	void Update(UserAddress obj);
}
