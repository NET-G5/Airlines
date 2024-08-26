using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(e => e.ID);
        
        builder.Property(e => e.RoleName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany(e => e.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleID);
    }
}