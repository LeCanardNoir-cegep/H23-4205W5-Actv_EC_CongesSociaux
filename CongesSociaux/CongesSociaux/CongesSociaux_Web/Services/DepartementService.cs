using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public class DepartementService : CrudServices<Departement>, IDepartementService<Departement>
    {
        public DepartementService(CongeSociauxDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Departement>> GetAllAsync()
        {
            return await _dbSet.Include( d => d.Enseignants ).ToListAsync();
        }
    }
}
