using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class Workout
    {
        // Primary Key
        public int WorkoutId { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [Display(Name = "Workout Name")]
        public required string WorkoutName { get; set; }

        [Required(ErrorMessage = "Please provide the day that the workout will take place")]
        [Display(Name = "Workout Day (Sunday = 1, Saturday = 7)")]
        public int WorkoutDay { get; set; }  // For specifying which day of the week


        // Foreign Key
        [Required(ErrorMessage = "You must have a microcycle created")]
        public int MicrocycleId { get; set; }

        // Navigation back to microcyle table
        public Microcycle? Microcycle { get; set; }

        // Linking forward to WorkoutExercise table
        public List<WorkoutExercise>? WorkoutExercises { get; set; }
    }
}
