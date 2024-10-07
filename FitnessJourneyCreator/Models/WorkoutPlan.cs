namespace FitnessJourneyCreator.Models
{
    public class WorkoutPlan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }

        // Getting the time/day that the workout plan was created 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
