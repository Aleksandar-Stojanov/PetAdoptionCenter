using PetAdoptionCenter.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Service.Interface
{
    public interface IRequestForAdoptionService
    {
        IEnumerable<RequestForAdoption> GetAllRequests();
        RequestForAdoption GetDetailsForRequest(Guid? id);
        RequestForAdoption CreateNewRequest(RequestForAdoption request);
        RequestForAdoption DeleteRequest(RequestForAdoption request);
    }
}
