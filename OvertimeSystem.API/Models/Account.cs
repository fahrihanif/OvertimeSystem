namespace OvertimeSystem.API.Models;

public class Account
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string Password { get; set; }
    public short? Otp { get; set; }
    public DateTime? Expired { get; set; }
    public bool IsUsed { get; set; }
    public bool IsActive { get; set; }

    public Employee Employee { get; set; }
    public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
}