using AirlineWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Controllers
{
    public class UserController : Controller
    {
        int userID = 1;
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
            var userId = userID; // Assume you have an extension method to get user ID
            var user = _userStore.GetById(userId);
            var bookings = _bookingStore.GetById(userId);
            
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserView
            {
                ID = user.ID,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash // Be cautious with this field; usually, we don't display it
            };

            return View(viewModel);
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
                PasswordHash = user.PasswordHash // Be cautious with this field; usually, we don't display it
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

                userEntitry.Username = model.Username;
                userEntitry.Email = model.Email;
                userEntitry.PasswordHash = model.PasswordHash; // Be cautious with this field; usually, we don't display it

                _userStore.Update(userEntitry.ToUpdateView());

                return RedirectToAction(nameof(Profile));
            }
            return View(model);
        }
    }
}
