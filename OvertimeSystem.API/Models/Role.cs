namespace OvertimeSystem.API.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
}