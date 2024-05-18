using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository
{
	public interface ITokenService
	{
		string CreateToken(AppUser appUser);
	}
}
