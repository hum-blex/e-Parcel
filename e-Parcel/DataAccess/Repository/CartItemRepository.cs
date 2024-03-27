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
			var existingItem = _db.CartItems.FirstOrDefault(x => x.Id == obj.Id);

            existingItem.Quantity = obj.Quantity;
            existingItem.Product = obj.Product;
            existingItem.SessionId = obj.SessionId;
            existingItem.ProductId = obj.ProductId;
            existingItem.Session = obj.Session;


            _db.CartItems.Update(obj);
		}

	}
}
