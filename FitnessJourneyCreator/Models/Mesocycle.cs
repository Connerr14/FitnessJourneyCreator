using System.ComponentModel.DataAnnotations;

namespace FitnessJourneyCreator.Models
{
    public class Mesocycle
    {
        // Primary Key
        public int MesocycleId { get; set; }

        [Required (ErrorMessage ="Please provide a name")]
        [Display(Name = "Mesocycle Name")]
        public required String MesocycleName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        // Forign Key
        [Required(ErrorMessage = "You must have a macrocyle created")]

        [Display(Name = "Macrocycle")]
        public int MacrocycleId { get; set; }

        [Display(Name = "Macrocycle")]
        // Linking back to Macrocycle
        public Macrocycle? Macrocycle { get; set; }

        // Linking forward to Microcycle table
        public List<Microcycle>? Microcycles { get; set; }



    }
}
