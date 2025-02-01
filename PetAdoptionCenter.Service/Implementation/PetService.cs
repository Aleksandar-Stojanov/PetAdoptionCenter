using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Repository.Interface;
using PetAdoptionCenter.Service.Interface;

namespace PetAdoptionCenter.Service.Implementation
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _petRepository;

        public PetService(IRepository<Pet> petRepository)
        {
            _petRepository = petRepository;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepository.GetAll();
        }

        public Pet GetDetailsForPet(Guid? id)
        {
            return _petRepository.Get(id);
        }

        public Pet CreateNewPet(Pet pet)
        {
            return _petRepository.Insert(pet);
        }

        public Pet UpdateExistingPet(Pet pet)
        {
            return _petRepository.Update(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            return _petRepository.Delete(pet);
        }
    }
}
