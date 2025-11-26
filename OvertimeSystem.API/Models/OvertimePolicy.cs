namespace OvertimeSystem.API.Models;

public class OvertimePolicy
{
    public Guid Id { get; set; }
    public string PolicyName { get; set; } = string.Empty;
    public ushort MaxDailyHours { get; set; }
    public ushort MaxWeeklyHours { get; set; }
    public TimeSpan WeekdayStartTime { get; set; }
    public TimeSpan WeekendStartTime { get; set; }
    public TimeSpan WeekendEndTime { get; set; }
    public bool IsActive { get; set; }
    
    // Cardinality
    public ICollection<OvertimeRequest>? OvertimeRequests { get; set; }
}