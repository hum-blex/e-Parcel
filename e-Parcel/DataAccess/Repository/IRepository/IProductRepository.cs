using e_Parcel.Models;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
	void Update(Product obj);
}
