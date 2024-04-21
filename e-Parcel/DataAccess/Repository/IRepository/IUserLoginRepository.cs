
using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUserLoginRepository : IRepository<UserLogin>
{
	void Update(UserLogin obj);
}
