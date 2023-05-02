using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongesSociaux_Web.ViewModels
{
    public class EnseignantVM
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        public DateTime DateEmbauche { get; set; }

        [Required]
        public string Specialite { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }
    }
}
