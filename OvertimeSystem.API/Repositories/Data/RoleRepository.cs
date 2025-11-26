using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}