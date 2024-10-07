namespace FitnessJourneyCreator.Models
{
    public class User
    {
        // Primary Key
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        // Linking to the workoutplan table
        public List<WorkoutPlan> WorkoutPlans { get; set; }

    }
}
