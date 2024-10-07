namespace FitnessJourneyCreator.Models
{
    public class Microcycle
    {
        public int CycleId { get; set; }
        public int MesocycleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
