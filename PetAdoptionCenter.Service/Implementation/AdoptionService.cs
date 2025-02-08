using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Repository.Interface;
using PetAdoptionCenter.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Service.Implementation
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IRepository<Adoption> repository;

        public AdoptionService(IRepository<Adoption> repository)
        {
            this.repository = repository;
        }

        public Adoption CreateNewAdoption(Adoption adoption)
        {
            return repository.Insert(adoption);
        }

        public Adoption DeleteAdoption(Adoption adoption)
        {
            return repository.Delete(adoption);
        }

        public IEnumerable<Adoption> GetAllAdoptions()
        {
            return repository.GetAll();
        }

        public Adoption GetDetailsForAdoption(Guid? id)
        {
            return repository.Get(id);
        }
    }
}
