using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessJourneyCreator.Models
{
    public class Log
    {
        // Holds the actual logs of the indivdual workouts

        // Primary Key
        public int LogId { get; set; }

        [Display(Name = "Date")]
        public DateTime DateLogged { get; set; }

        [Column(TypeName = "decimal(5, 2)")]

        // Adding the subscript "lbs" in the submission
        [DisplayFormat(DataFormatString = "{0} lbs")]
        public decimal? Weight { get; set; }

        [Required]
        [Display(Name = "Sets Completed")]
        public int SetsCompleted;

        [Required]
        [Display(Name = "Reps Completed")]
        public int RepsCompleted { get; set; }

        [Required]
        [Display(Name = "Workout Exercise")]
        // FK
        public int WorkoutExerciseId { get; set; }

        
        // Linking back to WorkoutExercise table
        public WorkoutExercise? WorkoutExercise { get; set; }
    }
}
