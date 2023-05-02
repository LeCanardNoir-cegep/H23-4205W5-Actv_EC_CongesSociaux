using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Controllers
{
    public class SoutiensController : Controller
    {
        private readonly CongeSociauxDbContext _context;

        public SoutiensController(CongeSociauxDbContext context)
        {
            _context = context;
        }

        // GET: Soutiens
        public async Task<IActionResult> Index()
        {
              return _context.Soutiens != null ? 
                          View(await _context.Soutiens.ToListAsync()) :
                          Problem("Entity set 'CongeSociauxDbContext.Soutiens'  is null.");
        }

        // GET: Soutiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Soutiens == null)
            {
                return NotFound();
            }

            var soutien = await _context.Soutiens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soutien == null)
            {
                return NotFound();
            }

            return View(soutien);
        }

        // GET: Soutiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soutiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Poste,Id,Prenom,Nom,DateEmbauche")] Soutien soutien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soutien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soutien);
        }

        // GET: Soutiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Soutiens == null)
            {
                return NotFound();
            }

            var soutien = await _context.Soutiens.FindAsync(id);
            if (soutien == null)
            {
                return NotFound();
            }
            return View(soutien);
        }

        // POST: Soutiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Poste,Id,Prenom,Nom,DateEmbauche")] Soutien soutien)
        {
            if (id != soutien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soutien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoutienExists(soutien.Id))
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
            return View(soutien);
        }

        // GET: Soutiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Soutiens == null)
            {
                return NotFound();
            }

            var soutien = await _context.Soutiens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soutien == null)
            {
                return NotFound();
            }

            return View(soutien);
        }

        // POST: Soutiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Soutiens == null)
            {
                return Problem("Entity set 'CongeSociauxDbContext.Soutiens'  is null.");
            }
            var soutien = await _context.Soutiens.FindAsync(id);
            if (soutien != null)
            {
                _context.Soutiens.Remove(soutien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoutienExists(int id)
        {
          return (_context.Soutiens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
