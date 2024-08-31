using Airline.Infrastructure;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.Booking;
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

        // GET: /Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookingView model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = GetUserId();
                _bookingStore.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Booking/Edit/5
        public IActionResult Edit(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null || booking.UserID != userId)
            {
                return Unauthorized();
            }

            return View(booking.ToUpdateView());
        }

        // POST: /Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateBookingView model)
        {
            if (ModelState.IsValid)
            {
                var userId = GetUserId();
                var booking = _bookingStore.GetById(id);

                if (booking == null || booking.UserID != userId)
                {
                    return Unauthorized();
                }

                _bookingStore.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Booking/Delete/5
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null || booking.UserID != userId)
            {
                return Unauthorized();
            }

            return View(booking);
        }

        // POST: /Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = GetUserId();
            var booking = _bookingStore.GetById(id);

            if (booking == null || booking.UserID != userId)
            {
                return Unauthorized();
            }

            _bookingStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Новый метод для получения UserID
        private int GetUserId()
        {
            return _context.Users.Where(x => x.ID == 1).Select(x => x.ID).FirstOrDefault();
        }
    }
}
