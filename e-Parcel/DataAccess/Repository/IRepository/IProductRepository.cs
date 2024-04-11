using e_Parcel.Models.Domain;
namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
	Task<Product> UpdateAsync(Guid id, Product obj);
}
