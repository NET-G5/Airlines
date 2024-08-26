using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class User : AuditableEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
}