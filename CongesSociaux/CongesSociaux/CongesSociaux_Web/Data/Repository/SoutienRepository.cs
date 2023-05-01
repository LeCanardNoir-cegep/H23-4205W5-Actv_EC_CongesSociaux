using CongesSociaux_Web.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongesSociaux_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CongesSociaux_Web.Data.Repository
{
    public class SoutienRepository : RepositoryAsync<Soutien>, ISoutienRepository
    {

        public SoutienRepository(CongeSociauxDbContext db) : base(db){}
    }
}
