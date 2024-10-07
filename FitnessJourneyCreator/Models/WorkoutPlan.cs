namespace FitnessJourneyCreator.Models
{
    public class WorkoutPlan
    {
        // Primary Key
        public int WorkoutPlanId { get; set; }

        public required string PlanName { get; set; }
        public required string PlanDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Linking PlanId to Macrocycle table
        public List<Macrocycle>? Macrocycles { get; set; }



    }
}
