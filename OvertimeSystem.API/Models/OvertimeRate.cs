namespace OvertimeSystem.API.Models;

public class OvertimeRate
{
    public Guid Id { get; set; }
    public string RateName { get; set; }
    public OvertimeDay DayType { get; set; }
    public short HourOrder { get; set; }
    public decimal Multiplier { get; set; }
    public int BaseDivisor { get; set; }
    
    public ICollection<ApprovedOvertime> ApprovedOvertimeRecords { get; set; } = new List<ApprovedOvertime>();
}