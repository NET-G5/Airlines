using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("Flight");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FlightNumber).IsRequired().HasMaxLength(20);
        builder.Property(e => e.DepartureTime).IsRequired();
        builder.Property(e => e.ArrivalTime).IsRequired();
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.Price).HasColumnType("decimal(18,2)");
        
        builder.HasMany(f => f.Bookings)
            .WithOne(b => b.Flight)
            .HasForeignKey(b => b.FlightId);
    }
}