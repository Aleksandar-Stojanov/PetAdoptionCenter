using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Domain.Domain_Models.DTO;
using PetAdoptionCenter.Repository;
using PetAdoptionCenter.Service.Implementation;
using PetAdoptionCenter.Service.Interface;

namespace PetAdoptionCenter.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService petService;
        private readonly IPersonService personService;
        private readonly IRequestForAdoptionService requestService;
        private readonly IAdoptionService adoptionService;
        private readonly ICenterService centerService;

        public PetsController(IAdoptionService adoptionService, ICenterService centerService, IRequestForAdoptionService requestService, IPetService petService, IPersonService personService)
        {
            this.requestService = requestService;
            this.petService = petService;
            this.personService = personService;
            this.centerService = centerService;
            this.adoptionService = adoptionService;
        }

        // GET: Pets
        public IActionResult Index()
        {
            return View(petService.GetAllPets());
        }

        // GET: Pets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetDetailsForPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            var dto = new PetCreationDTO()
            {
                Centers = centerService.GetAllCenters(),

            };
            return View(dto);
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CenterId,Name,Breed,DateOfBirth,Image")] PetCreationDTO dto)
        {
            if (ModelState.IsValid)
            {
                var pet = new Pet()
                {
                    Id = Guid.NewGuid(),
                    Breed = dto.Breed,
                    DateOfBirth = dto.DateOfBirth,
                    CenterId = dto.CenterId,
                    Image = dto.Image,
                    IsAdopted = false,
                    Name = dto.Name,
                    Center = centerService.GetDetailsForCenter(dto.CenterId),
                };
                pet.Id = Guid.NewGuid();
                petService.CreateNewPet(pet);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Pets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetDetailsForPet(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Breed,DateOfBirth,Id,Image")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    petService.UpdateExistingPet(pet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetDetailsForPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var pet = petService.GetDetailsForPet(id);
            if (pet != null)
            {
                petService.DeletePet(pet);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(Guid id)
        {
            var person = petService.GetDetailsForPet(id);
            if (person != null)
            {
                return true;
            }
            return false;
        }

        public IActionResult RequestAdoption(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pet = petService.GetDetailsForPet(id);
            var newrequest = new RequestForAdoptionDTO()
            {
                CenterId = pet.CenterId,
                Center = centerService.GetDetailsForCenter(pet.CenterId),
                PetId = id,
                Pet = pet,
                People = personService.GetAllPersons(),
            };
            if (pet == null)
            {
                return NotFound();
            }

            return View(newrequest);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRequest([Bind("PetId,UserId,CenterId")] RequestForAdoptionDTO dto)
        {
            var request = new RequestForAdoption()
            {
                Id = Guid.NewGuid(),
                PetId = dto.PetId,
                Pet = petService.GetDetailsForPet(dto.PetId),
                UserId = dto.UserId,
                User = personService.GetDetailsForPerson(dto.UserId),
                CenterId = dto.CenterId,
                Center = centerService.GetDetailsForCenter(dto.CenterId),
            };
            if (ModelState.IsValid)
            {
               requestService.CreateNewRequest(request);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SeeRequestsForPet(Guid? id)
        {
            var pet = petService.GetDetailsForPet(id);
            return View(pet);
        }
        


        public IActionResult ApproveAdoption(Guid? id)
        {
            var request = requestService.GetDetailsForRequest(id);
            var pet = petService.GetDetailsForPet(request.PetId);
            pet.IsAdopted = true;
            petService.UpdateExistingPet(pet);
            var adoption = new Adoption()
            {
                AdoptionDate = DateTime.Now,
                Center = centerService.GetDetailsForCenter(pet.CenterId),
                CenterId = pet.CenterId,
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Pet = pet,
                PetId = request.PetId,
                User = personService.GetDetailsForPerson(request.UserId),
            };
            adoptionService.CreateNewAdoption(adoption);
            
            return RedirectToAction(nameof(Index));
        }


    }
}
