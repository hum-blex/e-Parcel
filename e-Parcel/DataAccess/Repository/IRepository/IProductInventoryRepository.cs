using e_Parcel.Models.Domain;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IProductInventoryRepository : IRepository<ProductInventory>
{
	Task<ProductInventory> UpdateAsync(int id, ProductInventory obj);
}
