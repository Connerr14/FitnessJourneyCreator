using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessJourneyCreator.Data;
using FitnessJourneyCreator.Models;

namespace FitnessJourneyCreator.Controllers
{
    public class MacrocyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MacrocyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Macrocycles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Macrocycles.Include(m => m.WorkoutPlan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Macrocycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macrocycle = await _context.Macrocycles
                .Include(m => m.WorkoutPlan)
                .FirstOrDefaultAsync(m => m.MacrocycleId == id);
            if (macrocycle == null)
            {
                return NotFound();
            }

            return View(macrocycle);
        }

        // GET: Macrocycles/Create
        public IActionResult Create()
        {
            ViewData["WorkoutPlanId"] = new SelectList(_context.WorkoutPlans, "WorkoutPlanId", "PlanName");
            return View();
        }

        // POST: Macrocycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MacrocycleId,MacrocycleName,StartDate,EndDate,Description,WorkoutPlanId")] Macrocycle macrocycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(macrocycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkoutPlanId"] = new SelectList(_context.WorkoutPlans, "WorkoutPlanId", "PlanName", macrocycle.WorkoutPlanId);
            return View(macrocycle);
        }

        // GET: Macrocycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macrocycle = await _context.Macrocycles.FindAsync(id);
            if (macrocycle == null)
            {
                return NotFound();
            }
            ViewData["WorkoutPlanId"] = new SelectList(_context.WorkoutPlans, "WorkoutPlanId", "PlanName", macrocycle.WorkoutPlanId);
            return View(macrocycle);
        }

        // POST: Macrocycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MacrocycleId,MacrocycleName,StartDate,EndDate,Description,WorkoutPlanId")] Macrocycle macrocycle)
        {
            if (id != macrocycle.MacrocycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(macrocycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MacrocycleExists(macrocycle.MacrocycleId))
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
            ViewData["WorkoutPlanId"] = new SelectList(_context.WorkoutPlans, "WorkoutPlanId", "PlanName", macrocycle.WorkoutPlanId);
            return View(macrocycle);
        }

        // GET: Macrocycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macrocycle = await _context.Macrocycles
                .Include(m => m.WorkoutPlan)
                .FirstOrDefaultAsync(m => m.MacrocycleId == id);
            if (macrocycle == null)
            {
                return NotFound();
            }

            return View(macrocycle);
        }

        // POST: Macrocycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var macrocycle = await _context.Macrocycles.FindAsync(id);
            if (macrocycle != null)
            {
                _context.Macrocycles.Remove(macrocycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MacrocycleExists(int id)
        {
            return _context.Macrocycles.Any(e => e.MacrocycleId == id);
        }
    }
}
