using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Data.Repository
{
    public class SoutienRepository : RepositoryAsync<Soutien>, ISoutienRepository
    {
        private readonly DbContext _db;

        public SoutienRepository(DbContext db) : base(db)
        {
            _db = db;
        }
    }
}
