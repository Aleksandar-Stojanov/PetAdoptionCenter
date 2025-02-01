using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdoptionCenter.Domain.Domain_Models;

namespace PetAdoptionCenter.Service.Interface
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllPets();
        Pet GetDetailsForPet(Guid? id);
        Pet CreateNewPet(Pet pet);
        Pet UpdateExistingPet(Pet pet);
        Pet DeletePet(Pet pet);
    }
}
