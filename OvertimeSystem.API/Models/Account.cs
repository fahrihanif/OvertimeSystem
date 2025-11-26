namespace OvertimeSystem.API.Models;

public class Account
{
    public Guid EmployeeId { get; set; }
    public string Password { get; set; } = string.Empty;
    public uint? Otp { get; set; }
    public DateTime? Expired { get; set; }
    public bool IsUsed { get; set; }
    public bool IsActive { get; set; }
    
    // Cardinality
    public Employee? Employee { get; set; }
    public ICollection<AccountRole>? AccountRoles { get; set; }
}