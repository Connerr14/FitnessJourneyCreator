namespace FitnessJourneyCreator.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public int MicrocycleId { get; set; }
        public string WorkoutName { get; set; }
        public int WorkoutDay { get; set; }  // For specifying which day of the week
    }
}
