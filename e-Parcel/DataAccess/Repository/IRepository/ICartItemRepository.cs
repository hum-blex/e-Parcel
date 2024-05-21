using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface ICartItemRepository : IRepository<CartItem>
{
	Task<CartItem> UpdateAsync(Guid id, CartItem obj);
}
