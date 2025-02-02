using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Domain.Domain_Models.DTO
{
    public class PetCreationDTO
    {
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public string? Image { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? CenterId { get; set; }
        public IEnumerable<AdoptionCenter>? Centers { get; set; }
    }
}
