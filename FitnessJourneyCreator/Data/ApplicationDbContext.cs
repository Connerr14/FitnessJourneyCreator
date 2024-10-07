using FitnessJourneyCreator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessJourneyCreator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Declaration of my DB Sets
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Macrocycle> Macrocycles { get; set; }
        public DbSet<Mesocycle> Mesocycles { get; set; }
        public DbSet<Microcycle> Microcycles { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
