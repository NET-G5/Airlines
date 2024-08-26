using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable("Airport");
        builder.HasKey(e => e.ID);
        
        builder.Property(e => e.Name)
            .IsRequired().HasMaxLength(100);
        
        builder.HasOne(a => a.City)
            .WithMany(c => c.Airports)
            .HasForeignKey(a => a.CityID)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Country)
            .WithMany(c => c.Airports)
            .HasForeignKey(a => a.CountryID)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.DepartureFlights)
            .WithOne(f => f.DepartureAirport)
            .HasForeignKey(f => f.DepartureAirportID)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.ArrivalFlights)
            .WithOne(f => f.ArrivalAirport)
            .HasForeignKey(f => f.ArrivalAirportID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}