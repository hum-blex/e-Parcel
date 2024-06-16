using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUserLoginRepository : IRepository<UserLogin>
{
	void Update(UserLogin obj);
}
