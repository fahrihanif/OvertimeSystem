namespace OvertimeSystem.API.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    // Cardinality
    public ICollection<AccountRole>? AccountRoles { get; set; }
}