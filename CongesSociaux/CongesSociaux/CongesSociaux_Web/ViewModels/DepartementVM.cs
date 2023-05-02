using CongesSociaux_Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CongesSociaux_Web.ViewModels
{
    public class DepartementVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        public List<Enseignant>? Enseignants { get; set; }
    }
}
