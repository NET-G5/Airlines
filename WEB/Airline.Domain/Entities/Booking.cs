using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Booking : EntityBase
{
    public int UserID { get; set; }
    public int FlightID { get; set; }
    public DateTime BookingDate { get; set; }
    public string SeatNumber { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual User User { get; set; }
    public virtual Flight Flight { get; set; }
}