using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Role : AuditableEntity
{
    public string RoleName { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}