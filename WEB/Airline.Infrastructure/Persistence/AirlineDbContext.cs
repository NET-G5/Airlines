using System.Reflection;
using Airline.Domain.Entities;
using Airline.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Persistence;

public class AirlineDbContext : IdentityDbContext<User, Role, int>
{
    public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
        : base(options) {}
    
    public virtual DbSet<Airport> Airports { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Flight> Flights { get; set; }
    
    protected AirlineDbContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.AddInterceptors(new AuditInterceptor());
        }
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        #region Identity

        modelBuilder.Entity<IdentityUser<int>>(e =>
        {
            e.ToTable("User");
        });

        modelBuilder.Entity<IdentityUserClaim<int>>(e =>
        {
            e.ToTable("UserClaim");
        });

        modelBuilder.Entity<IdentityUserLogin<int>>(e =>
        {
            e.ToTable("UserLogin");
        });

        modelBuilder.Entity<IdentityUserToken<int>>(e =>
        {
            e.ToTable("UserToken");
        });

        modelBuilder.Entity<IdentityRole<int>>(e =>
        {
            e.ToTable("Role");
        });

        modelBuilder.Entity<IdentityRoleClaim<int>>(e =>
        {
            e.ToTable("RoleClaim");
        });

        modelBuilder.Entity<IdentityUserRole<int>>(e =>
        {
            e.ToTable("UserRole");
        });

        #endregion
    }

}
