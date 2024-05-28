using AirlinesSystem.Constants;
using AirlinesSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlinesSystem.Data;

public class AirlineDbContext : DbContext
{
    public DbSet<Aircraft> Aircrafts { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Crew> Crews { get; set; }
    public DbSet<FlightCrew> FlightCrews { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AccessLevel> AccessLevels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlightCrew>()
            .HasKey(fc => new { fc.FlightID, fc.CrewID });

        modelBuilder.Entity<Flight>()
            .HasOne(f => f.OriginAirport)
            .WithMany(a => a.OriginFlights)
            .HasForeignKey(f => f.OriginAirportID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Flight>()
            .HasOne(f => f.DestinationAirport)
            .WithMany(a => a.DestinationFlights)
            .HasForeignKey(f => f.DestinationAirportID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Flight>()
            .Property(f => f.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Crew>()
            .Property(c => c.Role)
            .HasConversion<string>();

        modelBuilder.Entity<FlightCrew>()
            .Property(fc => fc.AssignmentRole)
            .HasConversion<string>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DataBaseConstants.CONNECTION_STRING);
        base.OnConfiguring(optionsBuilder);
    }
}
