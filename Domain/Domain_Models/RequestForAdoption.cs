using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Domain.Domain_Models
{
    public class RequestForAdoption : BaseEntity
    {
        public Guid? PetId { get; set; }
        public Pet? Pet { get; set; }

        public Guid? UserId { get; set; }
        public Person? User { get; set; }

        public Guid? CenterId { get; set; }
        public AdoptionCenter? Center { get; set; }
    }
}
