using Microsoft.AspNetCore.Identity;

namespace Airline.Domain.Entities;
public class Role : IdentityRole<int>
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string RoleName { get; set; }
}
