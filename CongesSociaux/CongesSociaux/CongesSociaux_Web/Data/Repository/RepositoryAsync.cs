using CongesSociaux_Web.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CongesSociaux_Web.Data.Repository
{
	public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
	{
		private readonly DbContext _db;

		public RepositoryAsync(DbContext db)
		{
			_db = db;
		}

		public async Task<T?> GetAsync(T entity) 
		{
			return await _db.Set<T>().FindAsync(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync(
		    Expression<Func<T, bool>>? filter = null,
		    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		    string? includedProperties = null) 
		{
			IQueryable<T> query = _db.Set<T>();

			if (filter != null)
				query = query.Where(filter);

			if (includedProperties != null)
			{
				foreach (string property in includedProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
					query = query.Include(property);
			}

			if (orderBy != null)
				query = orderBy(query);

			return await query.ToListAsync();
		}

		public async Task<T?> GetFirstOrDefaultAsync(
		    Expression<Func<T, bool>>? filter = null,
		    string? includedProperties = null) 
		{
			IQueryable<T> query = _db.Set<T>();

			if (filter != null)
				query = query.Where(filter);

			if (includedProperties != null)
			{
				foreach (string property in includedProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
					query = query.Include(property);
			}

			return await query.FirstOrDefaultAsync();
		}

		public async Task AddAsync(T entity) 
		{
			await _db.Set<T>().AddAsync(entity);
		}

		public void Update(T entity) 
		{
			_db.Set<T>().Update(entity);
		}
		public void UpdateRange(IEnumerable<T> entities) 
		{
			_db.Set<T>().UpdateRange(entities);
		}

		public void Remove(T entity) 
		{
			_db.Set<T>().Remove(entity);
		}
		public void RemoveRange(IEnumerable<T> entities) 
		{
			_db.Set<T>().RemoveRange(entities);
		}
	}
}
