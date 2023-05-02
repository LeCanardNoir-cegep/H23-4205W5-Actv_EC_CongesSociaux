using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Services;
using CongesSociaux_Web.Services.Interfaces;
using CongesSociaux_Web.ViewModels;

namespace CongesSociaux_Web.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly IDepartementControllerService _departementService;

        public DepartementsController(IDepartementControllerService departementService)
        {
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
            var departement = await _departementService.Details((int)id);
            if (id == null || departement == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] DepartementVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departementService.Update(vm);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _departementService.IsExist(id))
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
            return View(vm);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isExist = await _departementService.IsExist((int)id);
            if (id == null || !isExist)
            {
                return NotFound();
            }

            var departement = await _departementService.Delete((int)id);
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
            if (await _departementService.EntityIsEmpty())
            {
                return Problem("Entity set 'CongeSociauxDbContext.Departements'  is null.");
            }

            await _departementService.Delete(id, true);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DepartementExistsAsync(int id)
        {
            return await _departementService.IsExist(id);
        }
    }
}
