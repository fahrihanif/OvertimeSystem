namespace OvertimeSystem.API.Models;

public class ApprovedOvertime
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid RateId { get; set; }
    public short TotalHours { get; set; }
    public decimal CalculatedCost { get; set; }
    public ApprovedOvertimeStatus Status { get; set; } 
    public byte[] Document { get; set; }

    public OvertimeRequest Request { get; set; }
    public OvertimeRate Rate { get; set; }
}