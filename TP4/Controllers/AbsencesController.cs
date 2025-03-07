using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbsenceManagement.Data;
using AbsenceManagement.Models;
using AbsenceManagement.ViewModels;

namespace AbsenceManagement.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var absences = await _context.Absences
                .Include(a => a.Eleve)
                .ToListAsync();
            return View(absences);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            ViewData["EleveID"] = new SelectList(_context.Eleves, "ID", "Nom");
            // Générer liste des semaines pour le dropdown (1-52)
            List<int> semaines = Enumerable.Range(1, 52).ToList();
            ViewData["Semaines"] = new SelectList(semaines);
            return View();
        }

        // POST: Absences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EleveID,Semaine,NbrAbsences")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                // Vérifier si une absence existe déjà pour cet élève à cette semaine
                var existingAbsence = await _context.Absences
                    .FirstOrDefaultAsync(a => a.EleveID == absence.EleveID && a.Semaine == absence.Semaine);
                
                if (existingAbsence != null)
                {
                    // Mettre à jour l'absence existante
                    existingAbsence.NbrAbsences = absence.NbrAbsences;
                    _context.Update(existingAbsence);
                }
                else
                {
                    // Créer une nouvelle absence
                    _context.Add(absence);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EleveID"] = new SelectList(_context.Eleves, "ID", "Nom", absence.EleveID);
            List<int> semaines = Enumerable.Range(1, 52).ToList();
            ViewData["Semaines"] = new SelectList(semaines, absence.Semaine);
            return View(absence);
        }

        // GET: Absences/Statistics
        public async Task<IActionResult> Statistics(int? eleveId, int? semaine)
        {
            var viewModel = new StatisticsViewModel();
            
            // Obtenir les absences par semaine pour un élève spécifique
            if (eleveId.HasValue)
            {
                var eleve = await _context.Eleves.FindAsync(eleveId.Value);
                if (eleve != null)
                {
                    viewModel.EleveNom = $"{eleve.Prenom} {eleve.Nom}";
                    viewModel.AbsencesParSemaine = await _context.Absences
                        .Where(a => a.EleveID == eleveId.Value)
                        .OrderBy(a => a.Semaine)
                        .ToListAsync();
                        
                    viewModel.TotalAbsences = viewModel.AbsencesParSemaine.Sum(a => a.NbrAbsences);
                }
            }
            
            // Obtenir le nombre d'absences pour une semaine spécifique
            if (semaine.HasValue)
            {
                viewModel.Semaine = semaine.Value;
                viewModel.AbsencesEnSemaine = await _context.Absences
                    .Where(a => a.Semaine == semaine.Value)
                    .Include(a => a.Eleve)
                    .ToListAsync();
            }
            
            // Préparer les listes pour les dropdowns
            ViewData["Eleves"] = new SelectList(_context.Eleves, "ID", "Nom");
            List<int> semaines = Enumerable.Range(1, 52).ToList();
            ViewData["Semaines"] = new SelectList(semaines);
            
            return View(viewModel);
        }
    }
}