using System.Reflection;
using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Airline.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Airline.Infrastructure;

public class AirlineDbContext : IdentityDbContext
{
    public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
        : base(options){}
    
    public virtual DbSet<Airport> Airports  { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Flight> Flights { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}