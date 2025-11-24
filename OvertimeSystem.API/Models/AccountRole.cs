namespace OvertimeSystem.API.Models;

public class AccountRole
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid RoleId { get; set; }

    public Account Account { get; set; }
    public Role Role { get; set; }
}