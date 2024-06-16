using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
	Task<OrderDetail> UpdateAsync(Guid id, OrderDetail obj);
}
