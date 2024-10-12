using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    // TO-DO - Add annotations like "lbs", - Add Page for easy navigation, - add nav bar links, add styling.
    public class WorkoutPlan
    {
        // Primary Key
        [Display(Name = "Workout Plan")]
        public int WorkoutPlanId { get; set; }

        [Display(Name = "Plan Name")]
        public required string PlanName { get; set; }

        [Display(Name = "Plan Description")]
        public required string PlanDescription { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Linking PlanId to Macrocycle table
        public List<Macrocycle>? Macrocycles { get; set; }



    }
}
