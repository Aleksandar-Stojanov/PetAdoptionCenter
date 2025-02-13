using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;
using PetAdoptionCenter.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Repository.Implementation
{
    public class PartnersRepository : IPartnersRepository
    {
        private readonly TravelAgencyDbContext context;
        private DbSet<Booking> entities;

        //string errorMessage = string.Empty;

        public PartnersRepository(TravelAgencyDbContext context)
        {
            this.context = context;
            entities = context.Set<Booking>();
        }
        public Booking Get(Guid? id)
        {
            return entities
                    .Include("TravelPackage")
                    .Include("TravelPackage.Accommodation")
                    .Include("User")
                    .First(s => s.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return entities
                  .Include("TravelPackage")
                  .Include("TravelPackage.Accommodation")
                  .Include("User")
                  .AsEnumerable();
        }
    }
}
