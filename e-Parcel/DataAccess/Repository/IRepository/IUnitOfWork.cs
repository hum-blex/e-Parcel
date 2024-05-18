namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
	ICartItemRepository CartItem { get; }
	ICategoryRepository Category { get; }
	IDiscountRepository Discount { get; }
	IOrderDetailRepository OrderDetail { get; }
	IOrderItemRepository OrderItem { get; }
	IPaymentDetailRepository PaymentDetail { get; }
	IProductRepository Product { get; }
	IProductInventoryRepository ProductInventory { get; }
	IShoppingSessionRepository ShoppingSession { get; }
	IUserAddressRepository UserAddress { get; }
	IUserPaymentRepository UserPayment { get; }

	Task SaveAsync();
}
