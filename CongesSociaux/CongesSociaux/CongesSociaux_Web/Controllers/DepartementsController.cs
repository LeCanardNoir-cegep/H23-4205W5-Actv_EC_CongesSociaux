using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Models.ViewModels;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Services;
using CongesSociaux_Web.Services.Interfaces;

namespace CongesSociaux_Web.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IDepartementControllerService _departementService;

        public DepartementsController(IUnitOfWork unitOfwork, IDepartementControllerService departementService)
        {
            _UnitOfWork = unitOfwork;
            _departementService = departementService;
        }

        // GET: Departements
        public async Task<IActionResult> Index()
        {
            var data = await _departementService.Index();
            return data != null 
                        ? View(data) 
                        : Problem("Entity set 'CongeSociauxDbContext.Departements'  is null.");
        }

        // GET: Departements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null ) 
                return NotFound();

            var departement = await _departementService.Details((int)id);

            if (departement == null) 
                return NotFound();

            return View(departement);
        }

        // GET: Departements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] DepartementVM vm)
        {
            if (ModelState.IsValid)
            {
                await _departementService.Create(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Departements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _UnitOfWork.Departements == null)
            {
                return NotFound();
            }

            var departement = await _UnitOfWork.Departements.GetFirstOrDefaultAsync(d => d.Id == id);
            if (departement == null)
            {
                return NotFound();
            }
            return View(departement);
        }

        // POST: Departements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] Departement departement)
        {
            if (id != departement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _UnitOfWork.Departements.Update(departement);
                    _UnitOfWork.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartementExists(departement.Id))
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
            return View(departement);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _UnitOfWork.Departements == null)
            {
                return NotFound();
            }

            var departement = await _UnitOfWork.Departements.GetFirstOrDefaultAsync(m => m.Id == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // POST: Departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_UnitOfWork.Departements == null)
            {
                return Problem("Entity set 'CongeSociauxDbContext.Departements'  is null.");
            }
            var departement = await _UnitOfWork.Departements.GetFirstOrDefaultAsync( d => d.Id == id );
            if (departement != null)
            {
                _UnitOfWork.Departements.Remove(departement);
            }
            
            _UnitOfWork.save();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartementExists(int id)
        {
          return (_UnitOfWork.Departements?.GetFirstOrDefaultAsync(e => e.Id == id) != null );
        }
    }
}
