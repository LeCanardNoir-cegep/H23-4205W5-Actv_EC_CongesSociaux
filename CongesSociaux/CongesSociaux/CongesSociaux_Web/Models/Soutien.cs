using System.ComponentModel.DataAnnotations;

namespace CongesSociaux_Web.Models
{
    public class Soutien: Employe
    {
        [Required]
        public string Poste { get; set; }
    }
}
