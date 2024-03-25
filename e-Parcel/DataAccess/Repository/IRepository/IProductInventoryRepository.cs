using e_Parcel.Models;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IProductInventoryRepository : IRepository<ProductInventory>
{
	void Update(ProductInventory obj);
}
