using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Models
{
    public class Eleve
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        [Required]
        public string Prenom { get; set; }
        
        [Required]
        public int Groupe { get; set; }
    }
}