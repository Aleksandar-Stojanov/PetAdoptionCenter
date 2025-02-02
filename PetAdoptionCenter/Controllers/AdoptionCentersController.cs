using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Repository;
using PetAdoptionCenter.Service.Implementation;
using PetAdoptionCenter.Service.Interface;

namespace PetAdoptionCenter.Controllers
{
    public class AdoptionCentersController : Controller
    {
        private readonly ICenterService centerService;
        public AdoptionCentersController(ICenterService centerService)
        {
            this.centerService = centerService;
        }

        // GET: AdoptionCenters
        public IActionResult Index()
        {
            return View(centerService.GetAllCenters());
        }

        // GET: AdoptionCenters/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionCenter = centerService.GetDetailsForCenter(id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }

            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdoptionCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Location,Id")] AdoptionCenter adoptionCenter)
        {
            if (ModelState.IsValid)
            {
                adoptionCenter.Id = Guid.NewGuid();
                centerService.CreateNewCenter(adoptionCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionCenter = centerService.GetDetailsForCenter(id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }
            return View(adoptionCenter);
        }

        // POST: AdoptionCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Location,Id")] AdoptionCenter adoptionCenter)
        {
            if (id != adoptionCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   centerService.UpdateExistingCenter(adoptionCenter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionCenterExists(adoptionCenter.Id))
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
            return View(adoptionCenter);
        }

        // GET: AdoptionCenters/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionCenter = centerService.GetDetailsForCenter(id);
            if (adoptionCenter == null)
            {
                return NotFound();
            }

            return View(adoptionCenter);
        }

        // POST: AdoptionCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adoptionCenter = centerService.GetDetailsForCenter(id);
            if (adoptionCenter != null)
            {
                centerService.DeleteCenter(adoptionCenter);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionCenterExists(Guid id)
        {
            var center = centerService.GetDetailsForCenter(id);
            if (center != null)
            {
                return true;
            }
            return false;
        }
    }
}
