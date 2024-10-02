using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class UserRole : EntityBase
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}