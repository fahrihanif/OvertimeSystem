using OvertimeSystem.API.Enums;

namespace OvertimeSystem.API.Models;

public class OvertimeRequest
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid PolicyId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public ushort RequestedHours { get; set; }
    public OvertimeStatus Status { get; set; } 
    public string Comment { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public OvertimeDayStatus RequestType { get; set; } 
    
    // Cardinality
    public Employee? Employee { get; set; }
    public OvertimePolicy? Policy { get; set; }
    public ApprovedOvertime? ApprovedOvertime { get; set; }
}