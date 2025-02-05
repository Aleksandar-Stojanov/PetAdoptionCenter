using Microsoft.AspNetCore.Mvc;
using PetAdoptionCenter.Service.Interface;

namespace PetAdoptionCenter.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly IAdoptionService adoptionService;

        public AdoptionsController(IAdoptionService adoptionService)
        {
            this.adoptionService = adoptionService;
        }

        public IActionResult Index()
        {
            var all_adoption = adoptionService.GetAllAdoptions();
            return View(all_adoption);
        }
    }
}
