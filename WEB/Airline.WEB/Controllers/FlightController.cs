using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airline.Domain.Entities;
using Airline.Infrastructure;
public class FlightsController : Controller
{
    private readonly AirlineDbContext _context;

    public FlightsController(AirlineDbContext context)
    {
        _context = context;
    }

    // GET: Flights
    public async Task<IActionResult> Index()
    {
        var flights = await _context.Flights
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .ToListAsync();
        return View(flights);
    }

    // GET: Flights/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // GET: Flights/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Flights/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,FlightNumber,DepartureAirportID,ArrivalAirportID,DepartureTime,ArrivalTime,Price")] Flight flight)
    {
        if (ModelState.IsValid)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: Flights/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
        {
            return NotFound();
        }
        return View(flight);
    }

    // POST: Flights/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,FlightNumber,DepartureAirportID,ArrivalAirportID,DepartureTime,ArrivalTime,Price")] Flight flight)
    {
        if (id != flight.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(flight);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(flight.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: Flights/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // POST: Flights/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FlightExists(int id)
    {
        return _context.Flights.Any(e => e.ID == id);
    }
}
