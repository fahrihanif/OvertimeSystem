using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class OvertimeBudgetRepository : Repository<OvertimeBudget>, IOvertimeBudgetRepository
{
    public OvertimeBudgetRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
    
    public async Task<OvertimeBudget?> GetActiveBudgetAsync(Guid employeeId, DateTime date, CancellationToken cancellationToken)
    {
        return await _context.OvertimeBudgets.Where(ob => ob.EmployeeId == employeeId && ob.BudgetMonth == date).FirstOrDefaultAsync(cancellationToken);
    }
}