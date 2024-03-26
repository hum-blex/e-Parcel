using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
	private ApplicationDbContext _db;
	public CartItemRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}
	public void Update(CartItem obj)
	{
		var existingDiscount = _db.CartItems.FirstOrDefault(x => x.Id == obj.Id);

		existingDiscount.Quantity = obj.Quantity;
		existingDiscount.Product = obj.Product;
		existingDiscount.SessionId = obj.SessionId;
		existingDiscount.ProductId = obj.ProductId;
		existingDiscount.Session = obj.Session;


		_db.CartItems.Update(obj);
	}

}
