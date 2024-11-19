using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessJourneyCreator.Data;
using FitnessJourneyCreator.Models;
using Microsoft.AspNetCore.Authorization;

namespace FitnessJourneyCreator.Controllers
{
    [Authorize]
    public class MesocyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesocyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mesocycles
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mesocycles.Include(m => m.Macrocycle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mesocycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesocycle = await _context.Mesocycles
                .Include(m => m.Macrocycle)
                .FirstOrDefaultAsync(m => m.MesocycleId == id);
            if (mesocycle == null)
            {
                return NotFound();
            }

            return View(mesocycle);
        }

        // GET: Mesocycles/Create
        public IActionResult Create()
        {
            ViewData["MacrocycleId"] = new SelectList(_context.Macrocycles, "MacrocycleId", "MacrocycleName");
            return View();
        }

        // POST: Mesocycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MesocycleId,MesocycleName,StartDate,EndDate,MacrocycleId")] Mesocycle mesocycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesocycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MacrocycleId"] = new SelectList(_context.Macrocycles, "MacrocycleId", "MacrocycleName", mesocycle.MacrocycleId);
            return View(mesocycle);
        }

        // GET: Mesocycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesocycle = await _context.Mesocycles.FindAsync(id);
            if (mesocycle == null)
            {
                return NotFound();
            }
            ViewData["MacrocycleId"] = new SelectList(_context.Macrocycles, "MacrocycleId", "MacrocycleName", mesocycle.MacrocycleId);
            return View(mesocycle);
        }

        // POST: Mesocycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MesocycleId,MesocycleName,StartDate,EndDate,MacrocycleId")] Mesocycle mesocycle)
        {
            if (id != mesocycle.MesocycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesocycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesocycleExists(mesocycle.MesocycleId))
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
            ViewData["MacrocycleId"] = new SelectList(_context.Macrocycles, "MacrocycleId", "MacrocycleName", mesocycle.MacrocycleId);
            return View(mesocycle);
        }

        // GET: Mesocycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesocycle = await _context.Mesocycles
                .Include(m => m.Macrocycle)
                .FirstOrDefaultAsync(m => m.MesocycleId == id);
            if (mesocycle == null)
            {
                return NotFound();
            }

            return View(mesocycle);
        }

        // POST: Mesocycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesocycle = await _context.Mesocycles.FindAsync(id);
            if (mesocycle != null)
            {
                _context.Mesocycles.Remove(mesocycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesocycleExists(int id)
        {
            return _context.Mesocycles.Any(e => e.MesocycleId == id);
        }
    }
}
