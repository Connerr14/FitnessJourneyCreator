using Microsoft.AspNetCore.Mvc;

namespace FitnessJourneyCreator.Controllers
{
    public class ProgramCatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
