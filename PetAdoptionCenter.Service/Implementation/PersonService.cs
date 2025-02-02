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
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public Person GetDetailsForPerson(Guid? id)
        {
            return _personRepository.Get(id);
        }

        public Person CreateNewPerson(Person person)
        {
            person.FullName = person.FirstName + " " + person.LastName;
            return _personRepository.Insert(person);
        }

        public Person UpdateExistingPerson(Person person)
        {
            person.FullName = person.FirstName + " " + person.LastName;
            return _personRepository.Update(person);
        }

        public Person DeletePerson(Person person)
        {
            return _personRepository.Delete(person);
        }
    }

}
