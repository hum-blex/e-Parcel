using e_Parcel.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace e_Parcel.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly ApplicationDbContext _db;
	internal DbSet<T> dbSet;

	public Repository(ApplicationDbContext db)
	{
		_db = db;
		this.dbSet = _db.Set<T>();
		// generics  eg. _db.Categories == dbSet
	}

	public async Task AddAsync(T entity)
	{
		await dbSet.AddAsync(entity);
	}

	public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
	{
		IQueryable<T> query = dbSet;
		// whatever filter/condition we have will be assigned to query
		query = query.Where(filter);

		if (!string.IsNullOrEmpty(includeProperties))
		{
			foreach (var includeProp in includeProperties.
				Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProp);
			}
		}
		return await query.FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
	{
		IQueryable<T> query = dbSet;


		if (!string.IsNullOrEmpty(includeProperties))
		{
			foreach (var includeProp in includeProperties.
				Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProp);
			}
		}
		return await query.ToListAsync();
	}

	public async Task RemoveAsync(T entity)
	{
		dbSet.Remove(entity);
	}

	public async Task RemoveRangeAsync(IEnumerable<T> entity)
	{
		dbSet.RemoveRange(entity);
	}
}
