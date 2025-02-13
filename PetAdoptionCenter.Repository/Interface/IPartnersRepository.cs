using PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Repository.Interface
{
    public interface IPartnersRepository
    {
        IEnumerable<Booking> GetAll();
        Booking Get(Guid? id);
    }
}
