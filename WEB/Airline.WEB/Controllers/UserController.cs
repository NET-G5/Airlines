using AirlineWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Controllers
{
    public class UserController : Controller
    {
        private int userID = 1;
        private readonly IUserStore _userStore;
        private readonly IBookingStore _bookingStore;

        public UserController(IUserStore userStore, IBookingStore bookingStore)
        {
            _userStore = userStore;
            _bookingStore = bookingStore;
        }

        // GET: /User/Profile
        public IActionResult Profile()
        {
            var user = _userStore.GetById(userID);

            if (user == null)
            {
                return NotFound();
            }

            var bookingsWithID = _bookingStore
                .GetAll("")
                .Where(b => b.UserID == userID)
                .ToList();

            ViewBag.Bookings = bookingsWithID;

            return View(user);
        }


        // GET: /User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _userStore.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UpdateUserView
            {
                ID = user.ID,
                Username = user.Username,
                Email = user.Email,
            };

            return View(viewModel);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateUserView model)
        {
            if (ModelState.IsValid)
            {
                var user = _userStore.GetById(model.ID);

                var userEntitry = user.ToView();
                
                
                if (user == null)
                {
                    return NotFound();
                }

                _userStore.Update(userEntitry.ToUpdateView());

                return RedirectToAction(nameof(Profile));
            }
            return View(model);
        }
    }
}
