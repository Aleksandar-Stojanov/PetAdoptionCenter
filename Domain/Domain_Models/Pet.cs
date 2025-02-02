using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Domain.Domain_Models
{
    public class Pet : BaseEntity
    {
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public string? Image { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsAdopted { get; set; }

        public AdoptionCenter? Center { get; set; }
        public Guid? CenterId { get; set; }
        public ICollection<Adoption>? Adoptions { get; set; }
        public ICollection<RequestForAdoption>? Requests { get; set; }
    }
}
