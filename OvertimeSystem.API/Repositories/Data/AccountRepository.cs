using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}