using CongesSociaux_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CongesSociaux_Web.Services.Interfaces
{
    public abstract class ADataAccessServicesBase<T> where T : class
    {
        protected CongeSociauxDbContext _db;
        protected DbSet<T> _dbSet;

        protected ADataAccessServicesBase(CongeSociauxDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
    }
}
