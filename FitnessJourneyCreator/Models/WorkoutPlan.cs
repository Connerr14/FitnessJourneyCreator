namespace FitnessJourneyCreator.Models
{
    public class WorkoutPlan
    {
        // Primary Key
        public int PlanId { get; set; }

        public required string PlanName { get; set; }
        public required string PlanDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // F.K
        public int UserId { get; set; }

        // Navigation back to user table
        public User User { get; set; }

        // Linking PlanId to Macrocycle table
        public List<Macrocycle>? Macrocycles { get; set; }



    }
}
