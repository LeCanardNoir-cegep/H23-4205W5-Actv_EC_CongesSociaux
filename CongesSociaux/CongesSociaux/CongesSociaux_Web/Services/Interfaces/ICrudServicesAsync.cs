namespace CongesSociaux_Web.Services.Interfaces
{
    public interface ICrudServicesAsync<T> where T : class
    {
        // CREATE
        Task<T> CreateAsync(T entity);
        // READ
        Task<T?> GetAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        // UPDATE
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        // DELETE
        void Delete();
        void DeleteRange(IEnumerable<T> entities);
    }
}
