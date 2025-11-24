namespace OvertimeSystem.API.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime JoinedDate { get; set; }
    public string Email { get; set; }
    public long Position { get; set; }
    public string Department { get; set; }
    public Guid? ManagerId { get; set; }

    public Employee Manager { get; set; }
    public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    public Account Account { get; set; }
    public ICollection<OvertimeRequest> OvertimeRequests { get; set; } = new List<OvertimeRequest>();
    public ICollection<OvertimeBudget> OvertimeBudgets { get; set; } = new List<OvertimeBudget>();
}