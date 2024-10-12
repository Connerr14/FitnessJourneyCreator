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
    public class LogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            // Adding a join between logs and the exercise table
            var logs = _context.Logs
                .Include(l => l.WorkoutExercise)
                .ThenInclude(C => C.Exercise)
                .ToList();
            return View(logs);
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.WorkoutExercise)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            // Adding a join between logs and the exercise table
            ViewData["WorkoutExerciseId"] = new SelectList(
                _context.WorkoutExercises.Include(we => we.Exercise)
                    .Select(we => new
                    {
                        WorkoutExerciseId = we.WorkoutExerciseId,
                        ExerciseName = we.Exercise.ExerciseName
                    }),
                "WorkoutExerciseId",
                "ExerciseName"
            );

            return View();

        }

        // POST: Logs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,DateLogged,Weight,RepsCompleted,WorkoutExerciseId")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Adding a join between logs and the exercise table
            ViewData["WorkoutExerciseId"] = new SelectList(
            _context.WorkoutExercises.Include(we => we.Exercise) // Include Exercise data
                .Select(we => new
                {
                    WorkoutExerciseId = we.WorkoutExerciseId,
                    ExerciseName = we.Exercise.ExerciseName
                }),
            "WorkoutExerciseId",
            "ExerciseName"
        );

            return View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }


            // Adding a join between logs and the exercise table
            ViewData["WorkoutExerciseId"] = new SelectList(
                _context.WorkoutExercises.Include(we => we.Exercise)
                    .Select(we => new
                    {
                        WorkoutExerciseId = we.WorkoutExerciseId,
                        ExerciseName = we.Exercise.ExerciseName
                    }),
                "WorkoutExerciseId",
                "ExerciseName"
            );
            return View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,DateLogged,Weight,RepsCompleted,WorkoutExerciseId")] Log log)
        {
            if (id != log.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.LogId))
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

            // Adding a join between logs and the exercise table
            ViewData["WorkoutExerciseId"] = new SelectList(
                _context.WorkoutExercises.Include(we => we.Exercise)
                    .Select(we => new
                    {
                        WorkoutExerciseId = we.WorkoutExerciseId,
                        ExerciseName = we.Exercise.ExerciseName
                    }),
                "WorkoutExerciseId",
                "ExerciseName"
            );
            
            return View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.WorkoutExercise)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
            return _context.Logs.Any(e => e.LogId == id);
        }
    }
}
