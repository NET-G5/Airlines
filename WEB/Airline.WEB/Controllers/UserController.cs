using Airline.Application.Requests.User;
using Airline.Application.Stores.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserStore _userStore;
        private readonly IBookingStore _bookingStore;

        public UserController(IUserStore userStore, IBookingStore bookingStore)
        {
            _userStore = userStore;
            _bookingStore = bookingStore;
        }

        // GET: /User/Profile
        public IActionResult Profile(UserRequest request)
        {
            var user = _userStore.GetById(request.Id);
            if (user == null)
            {
                return NotFound();
            }

            var bookingsWithID = _bookingStore
                .GetAll(request.Id, "")
                .Where(b => b.UserId == request.Id)
                .ToList();

            ViewBag.Bookings = bookingsWithID;
            return View(user);
        }

        // GET: /User/Edit/5
        public IActionResult Edit(UserRequest request)
        {
            var user = _userStore.GetById(request.Id);
            
            if (user == null)
            {
                return NotFound();
            }

            var userRequest = new UpdateUserRequest(
                user.Id,
                user.UserName,
                user.Email,
                "",
                null,
                false,
                false);

            return View(userRequest);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _userStore.GetById(request.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = request.UserName;
                user.Email = request.Email;

                _userStore.Update(request);
                return RedirectToAction(nameof(Profile), new { Id = user.Id });
            }

            return View(request);
        }
    }
}
