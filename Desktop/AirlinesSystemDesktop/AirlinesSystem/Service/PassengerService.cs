using AirlinesSystem.Data;
using AirlinesSystem.Models;

namespace AirlinesSystem.Service;

class PassengerService
{
    private List<Passenger> _passenger;

    public PassengerService()
    {
        for (int i = 0; i <= 200; i++)
        {
            _passenger.Add(DataGenerator.GeneratePassenger());
        }
    }

    public List<Passenger> GetPassengers(string search = "")
    {
        var passengers = new List<Passenger>();

        if (string.IsNullOrEmpty(search))
        {
            passengers = _passenger.Where(x => x.FirstName.Contains(search) ||
            x.LastName.Contains(search)).ToList();
        }

        return passengers;
    }

    public Passenger? GetpassengerByID(int id)
    {
        return _passenger.FirstOrDefault(x => x.ID == id)
            ?? new Passenger();
    }

    public void Create(Passenger passenger)
    {
        if (passenger != null)
        {
            _passenger.Add(passenger);
        }
    }

    public void Update(Passenger passenger)
    {
        if (passenger == null)
        {
            return;
        }

        var passengerID = _passenger.FirstOrDefault(x => x.ID == passenger.ID);

        if (passengerID == null)
        {
            return;
        }

        passengerID.FirstName = passenger.FirstName ?? passengerID.FirstName;
        passengerID.LastName = passenger.LastName ?? passengerID.LastName;
        passengerID.Email = passenger.Email ?? passengerID.Email;
        passengerID.PassportNumber = passenger.PassportNumber ?? passengerID.PassportNumber;
    }

    public void Delete(Passenger passenger)
    {
        if (passenger == null)
        {
            return;
        }

        var passengerID = _passenger.FirstOrDefault(x => x.ID == passenger.ID);

        if (passengerID == null)
        {
            return;
        }

        _passenger.Remove(passengerID);
    }
}
