using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");
        builder.HasKey(e => e.ID);
        builder.Property(e => e.BookingDate).IsRequired();
        builder.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
        builder.Property(e => e.TotalPrice).IsRequired();
    }
}