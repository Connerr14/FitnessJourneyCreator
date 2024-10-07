namespace FitnessJourneyCreator.Models
{
    public class Mesocycle
    {
        // Primary Key
        public int MesocycleId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Forign Key
        public int MacrocycleId { get; set; }

        // Linking back to Macrocycle
        public Macrocycle Macrocycle { get; set; }

        // Linking forward to Microcycle table
        public List<Microcycle> Microcycles { get; set; }



    }
}
