using System.ComponentModel.DataAnnotations;

namespace CongesSociaux_Web.Models
{
    public abstract class Employe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        public DateTime DateEmbauche { get; set; }

    }
}
