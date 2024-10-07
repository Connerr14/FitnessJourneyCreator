namespace FitnessJourneyCreator.Models
{
    public class Log
    {
        // Primary Key
        public int LogId { get; set; }
        public DateTime DateLogged { get; set; }
        public decimal? Weight { get; set; }
        public int SetsCompleted;
        public int? RepsCompleted { get; set; }

        // FK
        public int WorkoutExerciseId { get; set; }

        // Linking back to WorkoutExercise table
        public WorkoutExercise WorkoutExercise { get; set; }
    }
}
