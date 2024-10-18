using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;

namespace Airline.Infrastructure.Repositories;

public class CommonRepository : ICommonRepository
{
    private readonly AirlineDbContext _context;

    private IAirportRepository _airportRepository;
    public IAirportRepository Airports =>
        _airportRepository ??= new AirportRepository(_context);

    private IBookingRepository _bookingRepository;
    public IBookingRepository Bookings =>
        _bookingRepository ??= new BookingRepository(_context);

    private ICityRepository _cityRepository;
    public ICityRepository Cities =>
        _cityRepository ??= new CityRepository(_context);

    private ICountryRepository _countryRepository;
    public ICountryRepository Countries =>
        _countryRepository ??= new CountryRepository(_context);

    private IFlightRepository _flightRepository;
    public IFlightRepository Flights =>
        _flightRepository ??= new FlightRepository(_context);
    
    private IRoleRepository _roleRepository;
    public IRoleRepository Roles =>
        _roleRepository ??= new RoleRepository(_context);

    private IUserRepository _userRepository;
    public IUserRepository Users =>
        _userRepository ??= new UserRepository(_context);
    
    public CommonRepository(AirlineDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _airportRepository = new AirportRepository(context);
        _bookingRepository = new BookingRepository(context);
        _cityRepository = new CityRepository(context);
        _countryRepository = new CountryRepository(context);
        _flightRepository = new FlightRepository(context);
        _roleRepository = new RoleRepository(context);
        _userRepository = new UserRepository(context);
    }

    public int SaveChanges() =>
        _context.SaveChanges();
}