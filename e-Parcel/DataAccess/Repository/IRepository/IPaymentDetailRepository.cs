using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IPaymentDetailRepository : IRepository<PaymentDetail>
{
	void Update(PaymentDetail obj);
}
