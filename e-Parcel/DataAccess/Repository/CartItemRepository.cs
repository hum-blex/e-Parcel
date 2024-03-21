using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository
{
	public class CartItemRepository : Repository<CartItem>, ICartItemRepository
	{
		private ApplicationDbContext _db;
		public CartItemRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(CartItem obj)
		{
			_db.CartItems.Update(obj);
		}

	}
}
