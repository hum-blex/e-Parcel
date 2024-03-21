using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
	void Update(OrderDetail obj);
}
