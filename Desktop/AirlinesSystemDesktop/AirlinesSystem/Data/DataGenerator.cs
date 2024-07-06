using AirlinesSystem.Models;
using Bogus;

namespace AirlinesSystem.Data;
public static class DataGenerator
{
    private static Faker _faker = _faker = new Faker();

    public static Aircraft GenerateAircraft()
    {
        return new Faker<Aircraft>()
            .RuleFor(a => a.ID, f => f.Random.Number(1,9999))
            .RuleFor(a => a.Model, f => f.Commerce.ProductName())
            .RuleFor(a => a.Manufacturer, f => f.Company.CompanyName())
            .RuleFor(a => a.SeatingCapacity, f => f.Random.Number(50, 300));
    }

    public static Booking GenerateBooking()
    {
        return new Faker<Booking>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(b => b.FlightID, f => f.Random.Number(100, 999))
            .RuleFor(b => b.PassengerID, f => f.Random.Number(100, 999))
            .RuleFor(b => b.SeatNumber, f => f.Random.Word().Substring(1, 5))
            .RuleFor(b => b.BookingDate, f => f.Date.Recent());
    }

    public static Position GeneratePosition()
    {
        return new Faker<Position>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(p => p.PositionName, f => f.Name.JobTitle());
    }

    public static Employee GenerateEmployee()
    {
        return new Faker<Employee>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.PositionID, f => f.Random.Number(1, 5))
            .RuleFor(e => e.HireDate, f => f.Date.Past())
            .RuleFor(e => e.Email, f => f.Internet.Email())
            .RuleFor(e => e.Password, f => f.Internet.Password());
    }

    public static Flight GenerateFlight()
    {
        return new Faker<Flight>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(f => f.AircraftID, f => f.Random.Number(100, 999))
            .RuleFor(f => f.FromID, f => f.Random.Number(1, 10))
            .RuleFor(f => f.ToID, f => f.Random.Number(1, 10))
            .RuleFor(f => f.FlightStatus, f => f.PickRandom<FlightStatus>());
    }

    public static Passenger GeneratePassenger()
    {
        return new Faker<Passenger>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.PassportNumber, f => f.Random.AlphaNumeric(8))
            .RuleFor(p => p.Email, f => f.Internet.Email())
            .RuleFor(p => p.Password, f => f.Internet.Password());
    }

    public static Capital GenerateCapital()
    {
        return new Faker<Capital>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(c => c.CapitalName, f => f.Address.City())
            .RuleFor(c => c.Country, f => f.Address.Country());
    }

    public static User GenerateUser()
    {
        return new Faker<User>()
            .RuleFor(a => a.ID, f => f.Random.Number(1, 9999))
            .RuleFor(u => u.UserName, f => f.Internet.UserName())
            .RuleFor(u => u.Password, f => f.Internet.Password())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.EmployeeID, f => f.Random.Number(1000, 9999));
    }
}
