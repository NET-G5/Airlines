using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(e => e.ID);
        
        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(e => e.PasswordHash).IsRequired();
        
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        
        builder.HasMany(e => e.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserID);
        
        builder.HasMany(e => e.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserID);
    }
}