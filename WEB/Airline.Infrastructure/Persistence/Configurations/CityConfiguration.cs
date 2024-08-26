using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");
        builder.HasKey(e => e.ID);
        
        builder.Property(e => e.CityName)
            .IsRequired().
            HasMaxLength(100);
        
        builder.HasMany(c => c.Airports)
            .WithOne(a => a.City)
            .HasForeignKey(a => a.CityID);
    }
}