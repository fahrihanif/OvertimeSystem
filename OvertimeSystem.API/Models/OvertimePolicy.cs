namespace OvertimeSystem.API.Models;

public class OvertimePolicy
{
    public Guid Id { get; set; }
    public string PolicyName { get; set; } = string.Empty;
    public ushort MaxDailyHours { get; set; }
    public ushort MaxWeeklyHours { get; set; }
    public TimeOnly WeekdayStartTime { get; set; }
    public TimeOnly WeekendStartTime { get; set; }
    public TimeOnly WeekendEndTime { get; set; }
    public bool IsActive { get; set; }
    
    // Cardinality
    public ICollection<OvertimeRequest>? OvertimeRequests { get; set; }
}