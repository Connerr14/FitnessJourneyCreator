namespace FitnessJourneyCreator.Models
{
    public class Mesocycle
    {
        public int CycleId { get; set; }
        public int MacrocycleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
