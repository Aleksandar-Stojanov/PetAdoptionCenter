using PetAdoptionCenter.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Service.Interface
{
    public interface IAdoptionService
    {
        IEnumerable<Adoption> GetAllAdoptions();
        Adoption CreateNewAdoption(Adoption adoption);
        Adoption DeleteAdoption(Adoption adoption);

        Adoption GetDetailsForAdoption(Guid? id);
    }
}
