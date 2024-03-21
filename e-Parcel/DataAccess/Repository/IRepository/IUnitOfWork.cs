namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
	ICategoryRepository Category { get; }
	IProductInventoryRepository ProductInventory { get; }
	void Save();
}
