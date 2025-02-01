
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
    public class CenterService : ICenterService
    {
        private readonly IRepository<AdoptionCenter> _centerRepository;

        public CenterService(IRepository<AdoptionCenter> centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public List<AdoptionCenter> GetAllCenters()
        {
            return _centerRepository.GetAll().ToList();
        }

        public AdoptionCenter GetDetailsForCenter(Guid? id)
        {
            return _centerRepository.Get(id);
        }

        public AdoptionCenter CreateNewCenter(AdoptionCenter center)
        {
            return _centerRepository.Insert(center);
        }

        public AdoptionCenter UpdateExistingCenter(AdoptionCenter center)
        {
            return _centerRepository.Update(center);
        }

        public AdoptionCenter DeleteCenter(AdoptionCenter center)
        {
            return _centerRepository.Delete(center);
        }
    }
}
