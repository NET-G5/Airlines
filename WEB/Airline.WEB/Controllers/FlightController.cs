using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure;
using AirlineWeb.Mappings;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.Flight;
using AirlineWeb.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Controllers
{
    public class FlightController : Controller
    {
        private readonly IUserStore _userStore;
        private readonly IFlightStore _flightStore;

        public FlightController(ICommonRepository commonRepository, 
            IFlightStore flightStore, AirlineDbContext context, IUserStore userStore)
        {
            _userStore = userStore;
            _flightStore = flightStore;
        }

        // GET: /Flight/
        public IActionResult Index(string where = "", string to = "", string departure = "", string numberOfAdults=null)
        {
            var flights = _flightStore.GetAll(where, to, departure, numberOfAdults);

            ViewBag.where = where;
            ViewBag.to = to;
            ViewBag.departure = departure;
            ViewBag.numberOfAdults = numberOfAdults;
            
            return View(flights);
        }

        // GET: /Flight/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UpdateFlightView model)
        {
            if (ModelState.IsValid)
            {
                var flight = _flightStore.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Flight/Edit/5
        public IActionResult Edit(int id)
        {
            var flight = _flightStore.GetForUpdate(id);
            return View(flight);
        }

        // POST: /Flight/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateFlightView model)
        {
            if (ModelState.IsValid)
            {
                _flightStore.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Flight/Details/5
        public IActionResult Details(int id)
        {
            var flight = _flightStore.GetById(id);

            if (flight is null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: /Flight/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flightStore.GetById(id);

            if (flight is null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: /Flight/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _flightStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int userId, int flightId)
        {
            _userStore.AddFlightToUser(1, flightId);
            
            return View();
        }
        
        //private Flight ConvertFlight(int id)
        //{
        //    var flight = _context.Flights
        //        .Include(f => f.DepartureAirport)
        //        .ThenInclude(f => f.Country)
        //        .Include(f => f.ArrivalAirport)
        //        .ThenInclude( f => f.Country)
        //        .Include(f => f.DepartureAirport)
        //        .ThenInclude(a => a.City)
        //        .Include(f => f.ArrivalAirport)
        //        .ThenInclude(a => a.City)
        //        .FirstOrDefault(f => f.ID == id);

        //    return flight;
        //}
    }
}
