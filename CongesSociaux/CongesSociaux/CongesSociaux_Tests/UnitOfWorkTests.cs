using CongesSociaux_Web.Data;
using CongesSociaux_Web.Data.Repository;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services;
using CongesSociaux_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Tests
{
    public class UnitOfWorkTests
    {
        private DbContextOptions<CongeSociauxDbContext> _mockDbContextOptions;

        public UnitOfWorkTests() 
        {
            _mockDbContextOptions = new DbContextOptionsBuilder<CongeSociauxDbContext>().UseInMemoryDatabase("DbContextTest").Options;
        }

        [Fact]
        public async void GetAllDepartementsTest_OK()
        {
            // ARRANGE
            Departement departement = new Departement() { Id = 1, Name = "depFoo", Code = 300};
            Enseignant enseignant = new Enseignant() { Id = 1, Prenom = "Foo", Nom = "Bar", DepartementId = 1, Specialite = "Footer", DateEmbauche = new DateTime() };

            IEnumerable<Departement> result = null;

            // ACT
            using(  var mockDbContext = new CongeSociauxDbContext(_mockDbContextOptions))
            {
                mockDbContext.Database.EnsureDeletedAsync();
                await mockDbContext.AddAsync(departement);
                await mockDbContext.AddAsync(enseignant);
                await mockDbContext.SaveChangesAsync();

                IUnitOfWork service = new UnitOfWork(mockDbContext);

                result = await service.Departements.GetAllAsync();

            }

            // ASSERT
            Assert.Equal(1, result.Count());
            Assert.Equal("depFoo", result.First().Name);
            Assert.Equal("Footer", result.First().Enseignants.First().Specialite);

        }



        [Fact]
        public async void GetDepartementByIdTest_OK()
        {
            // ARRANGE
            Departement departement = new Departement() { Id = 1, Name = "depFoo", Code = 300 };
            Enseignant enseignant = new Enseignant() { Id = 1, Prenom = "Foo", Nom = "Bar", DepartementId = 1, Specialite = "Footer", DateEmbauche = new DateTime() };

            Departement result = null;

            // ACT
            using (var mockDbContext = new CongeSociauxDbContext(_mockDbContextOptions))
            {
                mockDbContext.Database.EnsureDeletedAsync();
                await mockDbContext.AddAsync(departement);
                await mockDbContext.AddAsync(enseignant);
                await mockDbContext.SaveChangesAsync();

                IUnitOfWork service = new UnitOfWork(mockDbContext);

                result = await service.Departements.GetFirstOrDefaultAsync( d => d.Id == 1 );

            }

            // ASSERT
            Assert.Equal(departement, result);
            Assert.Equal("depFoo", result.Name);
            Assert.Equal("Footer", result.Enseignants.First().Specialite);

        }
    }
}