using System.Linq.Expressions;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
	// link expression for FirstOrDefault eg. (u=>u.id == Id) 
	// using below parameter makes us easier to filter by not limiting the type of parameter
	Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
	Task AddAsync(T entity);
	Task RemoveAsync(T entity);
	Task RemoveRangeAsync(IEnumerable<T> entity);
}
