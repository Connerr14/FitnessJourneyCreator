namespace FitnessJourneyCreator.Models
{
    public class WorkoutExercise
    {
        // The junction table between the workout table and exersise table
        public int WorkoutExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
