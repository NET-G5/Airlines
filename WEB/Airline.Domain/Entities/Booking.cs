using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Booking : EntityBase
{
    public int UserId { get; set; }
    public int FlightId { get; set; }
    public DateTime BookingDate { get; set; }
    public required string SeatNumber { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual User User { get; set; }
    public virtual Flight Flight { get; set; }
}