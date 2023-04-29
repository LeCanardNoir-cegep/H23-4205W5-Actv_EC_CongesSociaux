using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services;
using CongesSociaux_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Tests
{
    public class DepartementServiceTests
    {
        private DbContextOptions<CongeSociauxDbContext> _mockDbContextOptions;

        public DepartementServiceTests() 
        {
            _mockDbContextOptions = new DbContextOptionsBuilder<CongeSociauxDbContext>().UseInMemoryDatabase("DbContextTest").Options;
        }

        [Fact]
        public async void GetAllDataOK()
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

                IDepartementService<Departement> service = new DepartementService(mockDbContext);

                result = await service.GetAllAsync();

            }

            // ASSERT
            Assert.Equal(1, result.Count());
            Assert.Equal("depFoo", result.First().Name);
            Assert.Equal("Footer", result.First().Enseignants.First().Specialite);

        }
    }
}