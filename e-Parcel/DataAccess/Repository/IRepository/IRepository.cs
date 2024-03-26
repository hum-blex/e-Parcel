using System.Linq.Expressions;

namespace e_Parcel.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
	IEnumerable<T> GetAll(string? includeProperties = null);
	// link expression for FirstOrDefault eg. (u=>u.id == Id) 
	// using below parameter makes us easier to filter by not limiting the type of parameter
	T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
	void Add(T entity);
	void Remove(T entity);
	void RemoveRange(IEnumerable<T> entity);
}
