using CongesSociaux_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Data
{
    public static class ModelBuilderDataGenarator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
            #region Departement
            builder.Entity<Departement>().HasData(new Departement() { Id = 1, Code = 300, Name = "Informatique" });
            #endregion

            #region Enseignant
            builder.Entity<Enseignant>().HasData(new Enseignant() { Id = 1, DepartementId = 1, Prenom = "Jacques", Nom="Trop-Moche", Specialite="On cherche toujours", DateEmbauche = new DateTime() });
            #endregion

            #region Soutient
            builder.Entity<Soutien>().HasData(new Soutien() { Id = 1, Prenom = "Viateur", Nom = "La Moppe", Poste = "Youpie", DateEmbauche = new DateTime()});
            #endregion
        }
    }
}
