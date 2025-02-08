using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Service.Interface;

namespace PetAdoptionCenter.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdoptionService _adoptionService;

        public AdminController(IAdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        [HttpPost("[action]")]
        public Adoption GetDetails(BaseEntity id)
        {
            return this._adoptionService.GetDetailsForAdoption(id.Id);
        }

    }
}
