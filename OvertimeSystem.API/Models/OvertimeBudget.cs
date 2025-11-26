namespace OvertimeSystem.API.Models;

public class OvertimeBudget
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime BudgetMonth { get; set; }
    public ushort InitialHours { get; set; }
    public ushort HoursConsumed { get; set; }
    
    // Cardinality
    public Employee? Employee { get; set; }
}