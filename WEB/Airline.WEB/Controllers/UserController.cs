using Airline.Domain.Entities;
using Airline.Infrastructure;
using AirlineWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Controllers
{
    public class UserController : Controller
    {
        int userID = 1;
        private readonly AirlineDbContext _context;
        private readonly IUserStore _userStore;
        private readonly IBookingStore _bookingStore;

        public UserController(IUserStore userStore, IBookingStore bookingStore)
        {
            _context = new();
            _userStore = userStore;
            _bookingStore = bookingStore;
        }

        // GET: /User/Profile
        public IActionResult Profile()
        {
            var userId = userID; // Assume you have an extension method to get user ID
            var user = ConvertUser(userId);
            
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = user.ToView();

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

        private User ConvertUser(int userID)
        {
            var user = _context.Users
                .Include(u => u.Bookings)
                .ThenInclude(b => b.Flight)
                .ThenInclude(f => f.ArrivalAirport)
                .ThenInclude(a => a.City)
                .Include(u => u.Bookings)
                .ThenInclude(b => b.Flight)
                .ThenInclude(f => f.DepartureAirport)
                .ThenInclude(a => a.City)
                .FirstOrDefault(u => u.ID == userID);

            return user;
        }
    }
}
