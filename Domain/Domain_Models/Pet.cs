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
        public int? Age { get; set; }

        public ICollection<Adoption>? Adoptions { get; set; }
    }
}
