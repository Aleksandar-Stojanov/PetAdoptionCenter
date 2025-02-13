using PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionCenter.Service.Interface
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetDetailsForBooking(Guid? id);
    }
}
