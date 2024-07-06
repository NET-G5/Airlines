using AirlinesSystem.Data;
using AirlinesSystem.Models;

namespace AirlinesSystem.Service;

public class EmployeeService
{
    private List<Employee> _employees;

    public EmployeeService()
    {
        for (int i = 0; i <= 200; i++)
        {
            _employees.Add(DataGenerator.GenerateEmployee());
        }
    }

    public List<Employee> GetEmployees(string search = "")
    {
        var employees = new List<Employee>();

        if (string.IsNullOrEmpty(search))
        {
            employees = _employees.Where(x => x.FirstName.Contains(search) ||
            x.LastName.Contains(search)).ToList();
        }

        return employees;
    }

    public Employee? GetEmployeeByID(int id)
    {
        return _employees.FirstOrDefault(x => x.ID == id)
            ?? new Employee();
    }

    public void Create(Employee employee)
    {
        if (employee != null)
        {
            _employees.Add(employee);
        }
    }

    public void Update(Employee employee)
    {
        if (employee == null)
        {
            return;
        }

        var employeeID = _employees.FirstOrDefault(x => x.ID == employee.ID);

        if (employeeID == null)
        {
            return;
        }

        employeeID.FirstName = employee.FirstName ?? employeeID.FirstName;
        employeeID.LastName = employee.LastName ?? employeeID.LastName;
        employeeID.Email = employee.Email ?? employeeID.Email;
        employeeID.Position = employee.Position ?? employeeID.Position;
        employeeID.PositionID = employee?.PositionID ?? employeeID.PositionID;
    }

    public void Delete(Employee employee)
    {
        if (employee == null)
        {
            return;
        }

        var employeeID = _employees.FirstOrDefault(x => x.ID == employee.ID);

        if (employeeID == null)
        {
            return;
        }

        _employees.Remove(employeeID);
    }
}
