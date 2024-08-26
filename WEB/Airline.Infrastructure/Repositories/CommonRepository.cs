using Airline.Domain.Interfaces;

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

    private IUserRoleRepository _userRoleRepository;
    public IUserRoleRepository UserRoles =>
        _userRoleRepository ??= new UserRoleRepository(_context);

    public int SaveChanges() =>
        _context.SaveChanges();
}