using AirlinesSystem.Data;
using AirlinesSystem.Models;

namespace AirlinesSystem.Service;

public class AircraftService
{
    private List<Aircraft> _aircrafts;

    public AircraftService()
    {
        for (int i = 0; i <= 10; i++)
        {
            _aircrafts.Add(DataGenerator.GenerateAircraft());
        }
    }

    public List<Aircraft> GetAircrafts(string search = "")
    {
        var aircrafts = new List<Aircraft>();

        if (string.IsNullOrEmpty(search))
        {
            aircrafts =  _aircrafts.Where(x => x.Model.Contains(search)).ToList();
        }

        return aircrafts;
    }

    public Aircraft? GetAircraftByID(int id)
    {
        return _aircrafts.FirstOrDefault(x => x.ID == id)
            ?? new Aircraft();
    }

    public void Create(Aircraft aircraft)
    {
        if (aircraft != null)
        {
            _aircrafts.Add(aircraft);
        }
    }

    public void Update(Aircraft aircraft)
    {
        if (aircraft == null)
        {
            return;
        }

        var aircraftID = _aircrafts.FirstOrDefault(x => x.ID == aircraft.ID);

        if (aircraftID == null)
        {
            return;
        }

        aircraftID.Manufacturer = aircraft.Manufacturer ?? aircraftID.Manufacturer;
        aircraftID.SeatingCapacity = aircraft?.SeatingCapacity ?? aircraftID.SeatingCapacity;
        aircraftID.Model = aircraft!.Model ?? aircraftID.Model;
    }

    public void Delete(Aircraft aircraft)
    {
        if (aircraft == null)
        {
            return;
        }

        var aircraftID = _aircrafts.FirstOrDefault(x => x.ID == aircraft.ID);

        if (aircraftID == null)
        {
            return;
        }

        _aircrafts.Remove(aircraftID);
    }
}
