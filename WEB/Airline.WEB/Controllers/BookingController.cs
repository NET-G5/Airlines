using Airline.Application.Requests.Booking;
using Airline.Application.Requests.User;
using Airline.Application.Stores.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index([FromQuery] GetBookingRequest request)
        {
            var userId = GetUserId();
            var bookings = _bookingStore.GetAll(request.UserId, "")
                .Where(b => b.UserId == userId).ToList();
            
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

            if (booking.UserId != userId)
            {
                return Unauthorized(); 
            }

            _bookingStore.Delete(booking.Id);

            return RedirectToAction("Index");
        }
        
        private int GetUserId()
        {
            return _userStore.GetAll("").Where(x => x.Id == 1).Select(x => x.Id).FirstOrDefault();
        }
    }
}
