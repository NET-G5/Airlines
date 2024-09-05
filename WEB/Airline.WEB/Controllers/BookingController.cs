using Airline.Infrastructure;
using AirlineWeb.Stores.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly AirlineDbContext _context;
        private readonly IBookingStore _bookingStore;

        public BookingController(AirlineDbContext context, IBookingStore bookingStore)
        {
            _context = new();
            _bookingStore = bookingStore;
        }

        // GET: /Booking/
        public IActionResult Index()
        {
            var userId = GetUserId();
            var bookings = _bookingStore.GetById(userId);
            return View(bookings);
        }
        
        public IActionResult Details(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null)
            {
                return Unauthorized();
            }

            return View(booking);
        }
        
        // GET: /Controller/Delete/5
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: /Controller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingStore.Delete(booking.UserID);

            return RedirectToAction("Index");
        }


        public IActionResult Add()
        {
            return RedirectToAction("Index", "Flight");
        }
        // Новый метод для получения UserID
        private int GetUserId()
        {
            return _context.Users.Where(x => x.ID == 1).Select(x => x.ID).FirstOrDefault();
        }
    }
}
