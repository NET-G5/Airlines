using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syncfusion.EJ2.Charts;

namespace Airline.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");
        builder.HasKey(e => e.ID);
        builder.Property(e => e.BookingDate).IsRequired();
        builder.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
        builder.Property(e => e.TotalPrice).IsRequired();
        builder.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
    }
}