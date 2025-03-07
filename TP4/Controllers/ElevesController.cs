// Controllers/ElevesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbsenceManagement.Data;
using AbsenceManagement.Models;

namespace AbsenceManagement.Controllers
{
    public class ElevesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElevesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eleves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eleves.ToListAsync());
        }

        // GET: Eleves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eleves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom,Groupe")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom,Groupe")] Eleve eleve)
        {
            if (id != eleve.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleveExists(eleve.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve != null)
            {
                _context.Eleves.Remove(eleve);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Eleves/Search
        public async Task<IActionResult> Search(string searchString)
        {
            var eleves = from e in _context.Eleves
                         select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                eleves = eleves.Where(s => s.Nom.Contains(searchString) || s.Prenom.Contains(searchString));
            }

            return View("Index", await eleves.ToListAsync());
        }

        private bool EleveExists(int id)
        {
            return _context.Eleves.Any(e => e.ID == id);
        }
    }
}