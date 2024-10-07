namespace FitnessJourneyCreator.Models
{
    public class Macrocycle
    {
        // Primary Key
        public int MacrocycleId { get; set; }

        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public String? description { get; set; }

        // FK
        public int PlanId { get; set; }

         // Navigation back to the workout plan
        public WorkoutPlan WorkoutPlan { get; set; }

        // Linking Mesocycle to Macrocycle 
        public List<Mesocycle> Mesocycles { get; set; }

    }
}
