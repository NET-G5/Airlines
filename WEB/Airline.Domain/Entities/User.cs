using Microsoft.AspNetCore.Identity;

namespace Airline.Domain.Entities;

public class User : IdentityUser<int>
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }

    public User()
    {
        UserRoles = [];
        Bookings = [];
    }
}