using OvertimeSystem.API.Enums;

namespace OvertimeSystem.API.Models;

public class OvertimeRate
{
    public Guid Id { get; set; }
    public string RateName { get; set; } = string.Empty;
    public OvertimeDayStatus DayType { get; set; }
    public ushort HourOrder { get; set; }
    public decimal Multiplier { get; set; }
    public int BaseDivisor { get; set; }
    
    public ICollection<ApprovedOvertime>? ApprovedOvertimes { get; set; }
}