using System.ComponentModel.DataAnnotations;

namespace CongesSociaux_Web.Models
{
    public class Departement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        public List<Enseignant>? Enseignants { get; set; } = null;

    }
}
