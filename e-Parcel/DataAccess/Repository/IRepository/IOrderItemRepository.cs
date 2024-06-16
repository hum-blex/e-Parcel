using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IOrderItemRepository : IRepository<OrderItem>
{
	Task<OrderItem> UpdateAsync(Guid id, OrderItem obj);
}
