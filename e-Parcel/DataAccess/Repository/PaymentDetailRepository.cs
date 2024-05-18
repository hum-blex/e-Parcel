using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
{
	private ApplicationDbContext _db;
	public PaymentDetailRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

	public async Task<PaymentDetail> UpdateAsync(Guid id, PaymentDetail obj)
	{
		var existingPaymentDetail = await _db.PaymentDetails.FindAsync(id);
		if (existingPaymentDetail == null) return null;
		existingPaymentDetail.Amount = obj.Amount;
		existingPaymentDetail.ModifiedOn = DateTime.Now;
		existingPaymentDetail.Status = obj.Status;
		existingPaymentDetail.Provider = obj.Provider;

		return existingPaymentDetail;
	}
}
