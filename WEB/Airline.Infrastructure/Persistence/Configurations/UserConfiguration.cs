using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(e => e.PasswordHash).IsRequired();
        
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        
        builder.HasMany(e => e.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);
    }
}