using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class WorkoutPlan
    {
        // Primary Key
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
