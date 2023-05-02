using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongesSociaux_Web.Models
{
    public class Enseignant : Employe
    {
        [Required]
        public string Specialite { get; set; }

        [ForeignKey(nameof(Departement))]
        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }
    }
}
