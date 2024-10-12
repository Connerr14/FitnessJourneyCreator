using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class Macrocycle
    {
        // Primary Key
        public int MacrocycleId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Macrocycle Name")]
        public String MacrocycleName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public String? Description { get; set; }

        // FK
        [Required(ErrorMessage = "You must have a workout plan created")]
        [Display(Name = "Workout Plan")]
        public int WorkoutPlanId { get; set; }

       
        [Display(Name = "Workout Plan")]
        // Navigation back to the workout plan
        public WorkoutPlan? WorkoutPlan { get; set; }

        [Display(Name = "Mesocycle")]
        // Linking Mesocycle to Macrocycle 
        public List<Mesocycle>? Mesocycles { get; set; }

    }
}
