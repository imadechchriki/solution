using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenceManagement.Models
{
    public class Absence
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int EleveID { get; set; }
        
        [ForeignKey("EleveID")]
        public Eleve Eleve { get; set; }
        
        [Required]
        public int Semaine { get; set; }
        
        [Required]
        public int NbrAbsences { get; set; }
    }
}