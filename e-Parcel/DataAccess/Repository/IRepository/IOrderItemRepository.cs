using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IOrderItemRepository : IRepository<OrderItem>
{
	void Update(OrderItem obj);
}
