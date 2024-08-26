using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(e => e.ID);
        
        builder.Property(e => e.CountryName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasMany(c => c.Cities)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.CountryID);
        
        builder.HasMany(c => c.Airports)
            .WithOne(a => a.Country)
            .HasForeignKey(a => a.CountryID);
    }
}