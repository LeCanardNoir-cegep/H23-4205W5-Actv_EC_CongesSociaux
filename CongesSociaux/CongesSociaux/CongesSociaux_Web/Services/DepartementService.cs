using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public class DepartementService : ADataAccessServicesBase<Departement>, IDepartementService<Departement>
    {
        public DepartementService(CongeSociauxDbContext db) : base(db){}

        public Task<Departement> CreateAsync(Departement entity)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Departement> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Departement>> GetAllAsync()
        {
            return await _dbSet.Include( d => d.Enseignants ).ToListAsync();
        }

        public Task<Departement?> GetAsync(Departement entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Departement?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync( d => d.Id == id);
        }

        public void Update(Departement entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Departement> entities)
        {
            throw new NotImplementedException();
        }
    }
}
