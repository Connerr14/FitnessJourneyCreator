namespace FitnessJourneyCreator.Models
{
    public class Macrocycle
    {
        public int CycleId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public String? description { get; set; }
    }
}
