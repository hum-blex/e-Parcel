
using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUserPaymentRepository : IRepository<UserPayment>
{
	void Update(UserPayment obj);
}
