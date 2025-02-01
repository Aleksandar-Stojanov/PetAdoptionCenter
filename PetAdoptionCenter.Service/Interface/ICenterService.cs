using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdoptionCenter.Domain.Domain_Models;

namespace PetAdoptionCenter.Service.Interface
{
    public interface ICenterService
    {
        List<AdoptionCenter> GetAllCenters();
        AdoptionCenter GetDetailsForCenter(Guid? id);
        AdoptionCenter CreateNewCenter(AdoptionCenter center);
        AdoptionCenter UpdateExistingCenter(AdoptionCenter center);
        AdoptionCenter DeleteCenter(AdoptionCenter center);
    }
}
