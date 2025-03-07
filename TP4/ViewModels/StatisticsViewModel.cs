// ViewModels/StatisticsViewModel.cs
using AbsenceManagement.Models;

namespace AbsenceManagement.ViewModels
{
    public class StatisticsViewModel
    {
        public string EleveNom { get; set; }
        public List<Absence> AbsencesParSemaine { get; set; } = new List<Absence>();
        public int TotalAbsences { get; set; }
        public int Semaine { get; set; }
        public List<Absence> AbsencesEnSemaine { get; set; } = new List<Absence>();
    }
}