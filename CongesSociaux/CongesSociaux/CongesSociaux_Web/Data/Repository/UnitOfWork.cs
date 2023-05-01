using CongesSociaux_Web.Data;
using CongesSociaux_Web.Data.Repository;
using CongesSociaux_Web.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongesSociaux_Web.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CongeSociauxDbContext _db;

        public IDepartementRepository Departements { get; private set; }
        public IEnseignantRepository Enseignants { get; private set; }
        public ISoutienRepository Soutiens { get; private set; }

        public UnitOfWork(CongeSociauxDbContext db)
        {
            _db = db;
            Departements = new DepartementRepository(_db);
            Enseignants = new EnseignantRepository(_db);
            Soutiens = new SoutienRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
