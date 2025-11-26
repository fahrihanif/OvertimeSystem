using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class OvertimeBudgetRepository : Repository<OvertimeBudget>, IOvertimeBudgetRepository
{
    public OvertimeBudgetRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}