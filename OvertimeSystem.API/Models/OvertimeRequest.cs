namespace OvertimeSystem.API.Models;

public class OvertimeRequest
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid PolicyId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public short RequestedHours { get; set; }
    public OvertimeStatus Status { get; set; } 
    public string Comment { get; set; }
    public DateTime Timestamp { get; set; }
    public OvertimeDay RequestType { get; set; } 

    public Employee Employee { get; set; }
    public OvertimePolicy Policy { get; set; }
    public ApprovedOvertime ApprovedOvertime { get; set; }
}