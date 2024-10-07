namespace FitnessJourneyCreator.Models
{
    public class Exercise
    {
        // Primary key
        public int ExerciseId { get; set; }

        public required string ExerciseName { get; set; }
        public string? Description { get; set; }
        public string? demostrationLink { get; set; }

        // Linking back to WorkoutExercise table
        public WorkoutExercise workoutExercise { get; set; }

    }
}
