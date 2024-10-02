using Microsoft.AspNetCore.Identity;

namespace Airline.Domain.Entities;
public class Role : IdentityRole<int>
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string RoleName { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }

    public Role()
    {
        UserRoles = [];
    }
}
