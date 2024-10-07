namespace FitnessJourneyCreator.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public DateTime DateLogged { get; set; }
        public decimal? Weight { get; set; }  // Weight can be nullable
        public int? Reps { get; set; }  // Reps can also be nullable
    }
}
