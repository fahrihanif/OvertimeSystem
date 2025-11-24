namespace OvertimeSystem.API.Models;

public class Overtime
{
    public Guid Id { get; set; }
    public DateTime Month { get; set; }
    public int TotalHours { get; set; }
}