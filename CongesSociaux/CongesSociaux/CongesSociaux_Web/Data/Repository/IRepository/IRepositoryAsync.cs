using System.Linq.Expressions;

namespace CongesSociaux_Web.Data.Repository.IRepository
{
	public interface IRepositoryAsync<T> where T : class
	{
		Task<T?> GetAsync(T entity);

		/// <summary>
		/// Retrieves the list of all entities of a given type.
		/// </summary>
		/// <typeparam name="T">The type of the entity.</typeparam>
		/// <param name="filter">A LINQ expression used to filter the list.</param>
		/// <param name="orderBy">A LINQ expression used to order the list.</param>
		/// <param name="includedProperties">A list of strings representing included properties.</param>
		/// <returns>The list of all entities of a given type.</returns>
		Task<IEnumerable<T>> GetAllAsync(
		    Expression<Func<T, bool>>? filter = null,
		    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		    string? includedProperties = null
		);

		/// <summary>
		/// Gets the first entity of a given type.
		/// </summary>
		/// <typeparam name="T">The type of the entity.</typeparam>
		/// <param name="filter">A LINQ expression used to filter the list.</param>
		/// <param name="includedProperties">A list of strings representing included properties.</param>
		/// <returns>The list of all entities of a given type.</param>
		/// <returns>The first entity of a given type, or null there is no such entity.</returns>
		Task<T?> GetFirstOrDefaultAsync(
		    Expression<Func<T, bool>>? filter = null,
		    string? includedProperties = null
		);

		Task AddAsync(T entity);
		void Update(T entity);
		void UpdateRange(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
