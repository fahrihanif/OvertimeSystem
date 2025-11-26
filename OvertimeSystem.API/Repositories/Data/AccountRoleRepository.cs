using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class AccountRoleRepository : Repository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}