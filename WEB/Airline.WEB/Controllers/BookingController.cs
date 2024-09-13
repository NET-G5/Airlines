using AirlineWeb.Stores.Interfaces;
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
        public IActionResult Index()
        {
            var userId = GetUserId();
            var bookings = _bookingStore.GetAll("")
                .Where(b => b.UserID == userId).ToList();
            
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

            _bookingStore.Delete(booking.ID);

            return RedirectToAction("Index");
        }
        
        private int GetUserId()
        {
            return _userStore.GetAll("").Where(x => x.ID == 1).Select(x => x.ID).FirstOrDefault();
        }
    }
}
