using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class Microcycle
    {
        // Primary Key
        public int MicrocycleId { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [Display(Name = "Microcycle Name")]
        public required String MicrocycleName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        // Foreign Key
        [Required(ErrorMessage = "You must have a mesocycle created")]
        public int MesocycleId { get; set; }

        // Navigation back to mesocycle
        public Mesocycle? Mesocycle { get; set; }

        // Linking to the workouts table
        public List<Workout>? Workouts { get; set; }

    }
}
