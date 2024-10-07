namespace FitnessJourneyCreator.Models
{
    public class Workout
    {
        // Primary Key
        public int WorkoutId { get; set; }
        public required string WorkoutName { get; set; }
        public int WorkoutDay { get; set; }  // For specifying which day of the week

        // Foreign Key
        public int MicrocycleId { get; set; }

        // Navigation back to microcyle table
        public Microcycle Microcycle { get; set; }

        // Linking forward to WorkoutExercise table
        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
