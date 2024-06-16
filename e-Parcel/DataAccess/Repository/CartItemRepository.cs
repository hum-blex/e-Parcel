using e_Parcel.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
	private ApplicationDbContext _db;
	public CartItemRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

    public async Task<CartItem> UpdateAsync(Guid id, CartItem obj)
    {
        var existingCartItem = await _db.CartItems.FirstOrDefaultAsync(x => x.Id == obj.Id);
        if (existingCartItem == null) return null;
        existingCartItem.Quantity = obj.Quantity;
        existingCartItem.Product = obj.Product;
        existingCartItem.SessionId = obj.SessionId;
        existingCartItem.ProductId = obj.ProductId;
        existingCartItem.Session = obj.Session;
        existingCartItem.ModifiedOn = DateTime.Now;


        return existingCartItem;
    }
}
