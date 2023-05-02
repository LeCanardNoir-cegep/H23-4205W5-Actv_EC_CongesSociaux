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
    public class EnseignantsController : Controller
    {
        private readonly CongeSociauxDbContext _unitOfWork;
        private readonly IEnseignantControllerService _enseignantService;

        public EnseignantsController(CongeSociauxDbContext context, IEnseignantControllerService enseignantService)
        {
            _unitOfWork = context;
            _enseignantService = enseignantService;
        }

        // GET: Enseignants
        public async Task<IActionResult> Index()
        {
            var data = await _enseignantService.Index();
            return View(data);
        }

        // GET: Enseignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _unitOfWork.Enseignants
                .Include(e => e.Departement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignants/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_unitOfWork.Departements, "Id", "Name");
            return View();
        }

        // POST: Enseignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Specialite,DepartementId,Id,Prenom,Nom,DateEmbauche")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Add(enseignant);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_unitOfWork.Departements, "Id", "Name", enseignant.DepartementId);
            return View(enseignant);
        }

        // GET: Enseignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _unitOfWork.Enseignants.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_unitOfWork.Departements, "Id", "Name", enseignant.DepartementId);
            return View(enseignant);
        }

        // POST: Enseignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Specialite,DepartementId,Id,Prenom,Nom,DateEmbauche")] Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Update(enseignant);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Id))
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
            ViewData["DepartementId"] = new SelectList(_unitOfWork.Departements, "Id", "Name", enseignant.DepartementId);
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _unitOfWork.Enseignants
                .Include(e => e.Departement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Enseignants == null)
            {
                return Problem("Entity set 'CongeSociauxDbContext.Enseignants'  is null.");
            }
            var enseignant = await _unitOfWork.Enseignants.FindAsync(id);
            if (enseignant != null)
            {
                _unitOfWork.Enseignants.Remove(enseignant);
            }
            
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
          return (_unitOfWork.Enseignants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
