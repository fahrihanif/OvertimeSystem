namespace OvertimeSystem.API.Models;

public class OvertimeBudget
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime BudgetMonth { get; set; }
    public short InitialHours { get; set; }
    public short HoursConsumed { get; set; }
    
    public Employee Employee { get; set; }
}