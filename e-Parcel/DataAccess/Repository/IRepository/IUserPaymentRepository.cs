using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUserPaymentRepository : IRepository<UserPayment>
{
	void Update(UserPayment obj);
}
