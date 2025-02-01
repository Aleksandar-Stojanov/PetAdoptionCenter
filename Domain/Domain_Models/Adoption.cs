using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Domain.Domain_Models
{
    public class Adoption : BaseEntity
    {
        public Guid? CenterId { get; set; }
        public AdoptionCenter? Center { get; set; }

        public Guid? PetId { get; set; }
        public Pet? Pet { get; set; }

        public Guid? UserId { get; set; }
        public Person? User { get; set; }

        public DateTime? AdoptionDate { get; set; }
    }
}
