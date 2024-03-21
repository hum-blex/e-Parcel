using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IShoppingSessionRepository : IRepository<ShoppingSession>
{
	void Update(ShoppingSession obj);
}
