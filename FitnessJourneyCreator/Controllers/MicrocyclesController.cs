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
    public class MicrocyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MicrocyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Microcycles
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Microcycles.Include(m => m.Mesocycle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Microcycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcycle = await _context.Microcycles
                .Include(m => m.Mesocycle)
                .FirstOrDefaultAsync(m => m.MicrocycleId == id);
            if (microcycle == null)
            {
                return NotFound();
            }

            return View(microcycle);
        }

        // GET: Microcycles/Create
        public IActionResult Create()
        {
            ViewData["MesocycleId"] = new SelectList(_context.Mesocycles, "MesocycleId", "MesocycleName");
            return View();
        }

        // POST: Microcycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MicrocycleId,MicrocycleName,StartDate,EndDate,MesocycleId")] Microcycle microcycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(microcycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesocycleId"] = new SelectList(_context.Mesocycles, "MesocycleId", "MesocycleName", microcycle.MesocycleId);
            return View(microcycle);
        }

        // GET: Microcycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcycle = await _context.Microcycles.FindAsync(id);
            if (microcycle == null)
            {
                return NotFound();
            }
            ViewData["MesocycleId"] = new SelectList(_context.Mesocycles, "MesocycleId", "MesocycleName", microcycle.MesocycleId);
            return View(microcycle);
        }

        // POST: Microcycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MicrocycleId,MicrocycleName,StartDate,EndDate,MesocycleId")] Microcycle microcycle)
        {
            if (id != microcycle.MicrocycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(microcycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MicrocycleExists(microcycle.MicrocycleId))
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
            ViewData["MesocycleId"] = new SelectList(_context.Mesocycles, "MesocycleId", "MesocycleName", microcycle.MesocycleId);
            return View(microcycle);
        }

        // GET: Microcycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcycle = await _context.Microcycles
                .Include(m => m.Mesocycle)
                .FirstOrDefaultAsync(m => m.MicrocycleId == id);
            if (microcycle == null)
            {
                return NotFound();
            }

            return View(microcycle);
        }

        // POST: Microcycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var microcycle = await _context.Microcycles.FindAsync(id);
            if (microcycle != null)
            {
                _context.Microcycles.Remove(microcycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MicrocycleExists(int id)
        {
            return _context.Microcycles.Any(e => e.MicrocycleId == id);
        }
    }
}
