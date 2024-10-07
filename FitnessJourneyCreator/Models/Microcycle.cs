namespace FitnessJourneyCreator.Models
{
    public class Microcycle
    {
        // Primary Key
        public int MicrocycleId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key
        public int MesocycleId { get; set; }

        // Navigation back to mesocycle
        public Mesocycle Mesocycle { get; set; }

        // Linking to the workouts table
        public List<Workout> Workouts { get; set; }

    }
}
