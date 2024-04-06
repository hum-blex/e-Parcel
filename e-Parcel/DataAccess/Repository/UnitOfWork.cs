using e_Parcel.DataAccess.Repository.IRepository;

namespace e_Parcel.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
	private ApplicationDbContext _db;
	public ICategoryRepository Category { get; private set; }
	public IProductInventoryRepository ProductInventory { get; private set; }
	public IDiscountRepository Discount { get; private set; }
	public ICartItemRepository CartItem { get; private set; }
	public IOrderDetailRepository OrderDetail { get; private set; }
	public IOrderItemRepository OrderItem { get; private set; }
	public IPaymentDetailRepository PaymentDetail { get; private set; }
	public IProductRepository Product { get; private set; }
	public IShoppingSessionRepository ShoppingSession { get; private set; }
	public IUserAddressRepository UserAddress { get; private set; }
	public IUserLoginRepository UserLogin { get; private set; }
	public IUserPaymentRepository UserPayment { get; private set; }

	public UnitOfWork(ApplicationDbContext db)
	{
		_db = db;
		CartItem = new CartItemRepository(_db);
		Category = new CategoryRepository(_db);
		Discount = new DiscountRepository(_db);
		OrderDetail = new OrderDetailRepository(_db);
		OrderItem = new OrderItemRepository(_db);
		PaymentDetail = new PaymentDetailRepository(_db);
		ProductInventory = new ProductInventoryRepository(_db);
		Product = new ProductRepository(_db);
		ShoppingSession = new ShoppingSessionRepository(_db);
		UserAddress = new UserAddressRepository(_db);
		UserLogin = new UserLoginRepository(_db);
		UserPayment = new UserPaymentRepository(_db);
	}

	public async Task SaveAsync()
	{
		await _db.SaveChangesAsync();
	}
}
