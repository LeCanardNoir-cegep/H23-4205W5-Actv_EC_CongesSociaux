using CongesSociaux_Web.Data;
using CongesSociaux_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public abstract class CrudServices<T> : ICrudServicesAsync<T> where T : class
    {
        protected CongeSociauxDbContext _db;
        protected DbSet<T> _dbSet;

        protected CrudServices(CongeSociauxDbContext db) 
        { 
            _db = db;
            _dbSet = _db.Set<T>();
        }

        // CREATE
        public virtual async Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        // READ
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // UPDATE
        public virtual async void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        // DELETE
        public virtual async void Delete()
        {
            throw new NotImplementedException();
        }

        public virtual async void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
