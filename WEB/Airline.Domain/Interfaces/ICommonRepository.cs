namespace Airline.Domain.Interfaces;

public interface ICommonRepository
{
    IAirportRepository Airports { get; }
    IBookingRepository Bookings { get; }
    ICityRepository Cities { get; }
    ICountryRepository Countries { get; }
    IFlightRepository Flights { get; }
    IRoleRepository Roles { get; }
    IUserRepository Users { get; }
    
    public int SaveChanges();
}