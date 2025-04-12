
using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
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

        public required string Goal { get; set; }

        [Display(Name = "Number of Weeks")]
        public int DurationWeeks { get; set; }



        public double Price { get; set; }

        [Display(Name = "Creator")]
        public required string CreatorName { get; set; }

        // Linking PlanId to Macrocycle table
        public List<Macrocycle>? Macrocycles { get; set; }
    }
}
