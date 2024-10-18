using Microsoft.AspNetCore.Identity;

namespace Airline.Domain.Entities;

public class User : IdentityUser<int>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }

    public User()
    {
        Bookings = [];
    }
}