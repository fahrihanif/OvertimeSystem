using OvertimeSystem.API.Enums;

namespace OvertimeSystem.API.Models;

public class Employee
{
    public Guid Id { get; set; }
    public int Nik { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public GenderEnum Gender { get; set; }
    public DateTime JoinedDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }
    
    
    // Cardinality
    public Account? Account { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    public Employee? Manager { get; set; }
    public ICollection<OvertimeRequest>? OvertimeRequests { get; set; } 
    public ICollection<OvertimeBudget>? OvertimeBudgets { get; set; } 
}