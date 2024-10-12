using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class WorkoutExercise
    {
        // The junction table between the workout table and exersise table
        // holds the actual logs of the indivdual workouts

        // Primary Key
        public int WorkoutExerciseId { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        // Foreign Keys
        [Display(Name = "Workout")]
        public int WorkoutId { get; set; }

        [Display(Name = "Exercise")]
        public int ExerciseId { get; set; }

        // Navigation to the workout table
        public Workout? Workout { get; set; }

        // Navigation to the exercise table
        public Exercise? Exercise { get; set; }

        // Linking forward to the Log table
        public List<Log>? Logs { get; set; }

    }
}
