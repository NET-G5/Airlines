using Airline.Domain.Entities;
using Airline.Infrastructure;
using AirlineWeb.Stores.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingStore _bookingStore;
        private readonly IUserStore _userStore;

        public BookingController(IBookingStore bookingStore, IUserStore userStore)
        {
            _userStore = userStore;
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

            if (booking.UserID != userId)
            {
                return Unauthorized(); 
            }

            _bookingStore.Delete(booking.UserID); // Убедитесь, что используете правильный идентификатор

            return RedirectToAction("Index");
        }
        
        // Новый метод для получения UserID
        private int GetUserId()
        {
            return _userStore.GetAll("").Where(x => x.ID == 1).Select(x => x.ID).FirstOrDefault();
        }
        //private Booking ConvertBooking(int id)
        //{
        //    var booking = _context.Bookings
        //        .Include(f => f.Flight)
        //        .ThenInclude(f => f.DepartureAirport)
        //        .ThenInclude(a => a.Country)
        //        .Include(f => f.Flight)
        //        .ThenInclude(f => f.ArrivalAirport)
        //        .ThenInclude(a => a.Country)
        //        .Include(a => a.Flight)
        //        .ThenInclude(f => f.DepartureAirport)
        //        .ThenInclude(a => a.City)
        //        .Include(a => a.Flight)
        //        .ThenInclude(f => f.ArrivalAirport)
        //        .ThenInclude(a => a.City)
        //        .FirstOrDefault(f => f.ID == id);
    
        //    return booking;
        //}
    }
}
