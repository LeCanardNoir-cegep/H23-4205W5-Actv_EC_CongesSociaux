using CongesSociaux_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace CongesSociaux_Web.Data
{
    public class CongeSociauxDbContext : IdentityDbContext
    {
       


        public CongeSociauxDbContext(DbContextOptions<CongeSociauxDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Soutien> Soutiens { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Departement> Departements { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.GenerateData();
        }

    }
}