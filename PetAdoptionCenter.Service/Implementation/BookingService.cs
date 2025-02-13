using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;
using PetAdoptionCenter.Repository.Interface;
using PetAdoptionCenter.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IPartnersRepository repository;

        public BookingService(IPartnersRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return repository.GetAll();
        }

        public Booking GetDetailsForBooking(Guid? id)
        {
            return repository.Get(id);
        }
    }
}
