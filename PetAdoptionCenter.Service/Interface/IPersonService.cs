using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdoptionCenter.Domain.Domain_Models;

namespace PetAdoptionCenter.Service.Interface
{
    public interface IPersonService
    {
        List<Person> GetAllPersons();
        Person GetDetailsForPerson(Guid? id);
        Person CreateNewPerson(Person person);
        Person UpdateExistingPerson(Person person);
        Person DeletePerson(Person person);
    }
}
