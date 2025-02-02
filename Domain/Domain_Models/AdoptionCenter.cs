using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Domain.Domain_Models
{
    public class AdoptionCenter : BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }

        public ICollection<Pet>? Pets { get; set; }

    }
}
