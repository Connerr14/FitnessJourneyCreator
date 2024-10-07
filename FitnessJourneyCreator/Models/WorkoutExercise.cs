namespace FitnessJourneyCreator.Models
{
    public class WorkoutExercise
    {
        // The junction table between the workout table and exersise table

        // Primary Key
        public int WorkoutExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        // Foreign Keys
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        // Navigation to the workout table
        public Workout Workout { get; set; }

        // Navigation to the exercise table
        public Exercise Exercise { get; set; }

        // Linking forward to the Log table
        public List<Log> Logs { get; set; }

    }
}
