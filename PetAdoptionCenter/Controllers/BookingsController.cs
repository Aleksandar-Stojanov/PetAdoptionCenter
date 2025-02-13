using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Repository;
using PetAdoptionCenter.Service.Interface;


namespace PetAdoptionCenter.Controllers
{
    public class BookingsController : Controller
    {
        // GET: BookingsController
        private readonly TravelAgencyDbContext _context;
        private readonly IBookingService bookingService;
        public BookingsController(IBookingService bookingService, TravelAgencyDbContext context)
        {
            _context = context;
            this.bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var bookings = bookingService.GetAllBookings().ToList();
            return View(bookings);
        }

        // GET: BookingsController/Details/5
        public ActionResult Details(Guid id)
        {
            var booking = bookingService.GetDetailsForBooking(id);
            return View(booking);
        }
    }
}
