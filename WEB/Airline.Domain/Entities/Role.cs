namespace Airline.Domain.Entities;

public class Role
{
    public int ID { get; set; }
    public string RoleName { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}