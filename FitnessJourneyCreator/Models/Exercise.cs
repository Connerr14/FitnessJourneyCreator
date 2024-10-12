using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class Exercise
    {
        // Primary key
        public int ExerciseId { get; set; }

        [Display(Name = "Exercise Name")]
        public required string ExerciseName { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Demonstration Link")]
        public string? DemostrationLink { get; set; }

        [Display(Name = "Workout Exercise")]
        // Linking back to WorkoutExercise table
        public WorkoutExercise? workoutExercise { get; set; }

    }
}
