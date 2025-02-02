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
    public class RequestForAdoptionService : IRequestForAdoptionService
    {
        private readonly IRepository<RequestForAdoption> repository;

        public RequestForAdoptionService(IRepository<RequestForAdoption> repository)
        {
            this.repository = repository;
        }

        public RequestForAdoption CreateNewRequest(RequestForAdoption request)
        {
            return repository.Insert(request);
        }

        public RequestForAdoption DeleteRequest(RequestForAdoption request)
        {
            return repository.Delete(request);
        }

        public IEnumerable<RequestForAdoption> GetAllRequests()
        {
            return repository.GetAll();
        }

        public RequestForAdoption GetDetailsForRequest(Guid? id)
        {
            return repository.Get(id);
        }
    }
}
