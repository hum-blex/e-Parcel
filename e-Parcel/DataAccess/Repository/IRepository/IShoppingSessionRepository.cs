using e_Parcel.Models;
using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IShoppingSessionRepository : IRepository<ShoppingSession>
{
    Task<ShoppingSession> UpdateAsync(Guid id, ShoppingSession obj);
}
