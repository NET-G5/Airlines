using Airline.Domain.Entities;
using Airline.Infrastructure;
using Bogus;

namespace AirlineWeb.Extensions;

public static class DatabaseInitializer
{
    private readonly static Faker _faker = new();

    public static void GenerateAllData(AirlineDbContext context)
    {
        try
        {
            CreateCountries(context);
            CreateCities(context);
            CreateAirports(context);
            CreateFlights(context);
            CreateUsers(context);
            CreateRoles(context);
            // CreateUserRoles(context);
            CreateBookings(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при инициализации базы данных: {ex.Message}");
        }
    }

    public static void CreateCountries(AirlineDbContext context)
    {
        if (context.Countries.Any()) return;

        for (int i = 0; i < 100; i++)
        {
            var country = new Country
            {
                CountryName = _faker.Address.Country()
            };

            context.Countries.Add(country);
        }

        context.SaveChanges();
    }

    public static void CreateCities(AirlineDbContext context)
    {
        if (context.Cities.Any()) return;

        var countries = context.Countries.ToList(); // Получаем список стран для связи
        for (int i = 0; i < 200; i++)
        {
            var city = new City
            {
                CityName = _faker.Address.City(),
                CountryID = _faker.PickRandom(countries).ID // Связываем с существующей страной
            };

            context.Cities.Add(city);
        }

        context.SaveChanges();
    }

    public static void CreateAirports(AirlineDbContext context)
    {
        if (context.Airports.Any()) return;

        var cities = context.Cities.ToList(); // Получаем список городов для связи
        var countries = context.Countries.ToList(); // Получаем список стран для связи
        for (int i = 0; i < 100; i++)
        {
            var airport = new Airport
            {
                Name = _faker.Address.StreetName() + " Airport",
                CityID = _faker.PickRandom(cities).ID, // Связываем с существующим городом
                CountryID = _faker.PickRandom(countries).ID // Связываем с существующей страной
            };

            context.Airports.Add(airport);
        }

        context.SaveChanges();
    }

    public static void CreateFlights(AirlineDbContext context)
    {
        if (context.Flights.Any()) return;

        var airports = context.Airports.ToList(); // Получаем список аэропортов для связи
        for (int i = 0; i < 100; i++)
        {
            var departureAirport = _faker.PickRandom(airports);
            var arrivalAirport = _faker.PickRandom(airports);

            var flight = new Flight
            {
                FlightNumber = _faker.Random.AlphaNumeric(6).ToUpper(),
                DepartureAirportID = departureAirport.ID,
                ArrivalAirportID = arrivalAirport.ID,
                DepartureTime = _faker.Date.Future(),
                ArrivalTime = _faker.Date.Future(),
                Price = _faker.Finance.Amount(100, 1000)
            };

            context.Flights.Add(flight);
        }

        context.SaveChanges();
    }

    public static void CreateUsers(AirlineDbContext context)
    {
        if (context.Users.Any()) return;

        for (int i = 0; i < 200; i++)
        {
            var user = new User
            {
                UserName = _faker.Internet.UserName(),
                PasswordHash = _faker.Internet.Password(),
                Email = _faker.Internet.Email()
            };

            context.Users.Add(user);
        }

        context.SaveChanges();
    }

    public static void CreateRoles(AirlineDbContext context)
    {
        if (context.Roles.Any()) return;

        var roles = new List<string> { "Admin", "User", "Manager" };

        foreach (var roleName in roles)
        {
            var role = new Role
            {
                RoleName = roleName
            };

            context.Roles.Add(role);
        }

        context.SaveChanges();
    }

    // public static void CreateUserRoles(AirlineDbContext context)
    // {
    //     if (context.UserRoles.Any()) return;
    //
    //     var users = context.Users.ToList(); // Получаем список пользователей для связи
    //     var roles = context.Roles.ToList(); // Получаем список ролей для связи
    //
    //     var uniqueUserRoles = new HashSet<(int UserID, int RoleID)>();
    //
    //     while (uniqueUserRoles.Count < 200)
    //     {
    //         var userID = _faker.PickRandom(users).ID;
    //         var roleID = _faker.PickRandom(roles).ID;
    //
    //         var userRolePair = (userID, roleID);
    //
    //         if (!uniqueUserRoles.Contains(userRolePair))
    //         {
    //             uniqueUserRoles.Add(userRolePair);
    //
    //             var userRole = new UserRole
    //             {
    //                 UserID = userID,
    //                 RoleID = roleID
    //             };
    //
    //             context.UserRoles.Add(userRole);
    //         }
    //     }
    //
    //     context.SaveChanges();
    // }


    public static void CreateBookings(AirlineDbContext context)
    {
        if (context.Bookings.Any()) return;

        var users = context.Users.ToList(); // Получаем список пользователей для связи
        var flights = context.Flights.ToList(); // Получаем список рейсов для связи

        for (int i = 0; i < 200; i++)
        {
            var booking = new Booking
            {
                UserID = _faker.PickRandom(users).ID,
                FlightID = _faker.PickRandom(flights).ID,
                BookingDate = _faker.Date.Recent(),
                SeatNumber = _faker.Random.String2(5, "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"),
                TotalPrice = _faker.Finance.Amount(100, 1000)
            };

            context.Bookings.Add(booking);
        }

        context.SaveChanges();
    }
}