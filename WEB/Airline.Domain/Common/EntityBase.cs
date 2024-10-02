namespace Airline.Domain.Common;

public abstract class EntityBase
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}