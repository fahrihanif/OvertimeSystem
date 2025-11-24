namespace OvertimeSystem.API.Models;

public class OvertimePolicy
{
    public Guid Id { get; set; }
    public string PolicyName { get; set; }
    public short MaxDailyHours { get; set; }
    public short MaxWeeklyHours { get; set; }
    public TimeSpan WeekdayStartTime { get; set; }
    public TimeSpan WeekendStartTime { get; set; }
    public TimeSpan WeekendEndTime { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<OvertimeRequest> OvertimeRequests { get; set; } = new List<OvertimeRequest>();
}