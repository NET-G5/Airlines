using Microsoft.EntityFrameworkCore;
using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");
        builder.HasKey(e => e.ID);
        builder.HasIndex(e => new { e.UserID, e.RoleID }).IsUnique();
    }
}