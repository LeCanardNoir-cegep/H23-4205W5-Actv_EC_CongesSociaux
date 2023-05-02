using CongesSociaux_Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CongesSociaux_Web.ViewModels
{
	public class SoutienVM
	{
		public int Id { get; set; }
		public string? Prenom { get; set; }
		public string? Nom { get; set; }
		public DateTime DateEmbauche { get; set; }
		public string? Poste { get; set; }
	}
}
