using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(OvertimeSystemDbContext context) : base(context)
    {
    }   

    public async Task<int> GetLastEmployeeId(CancellationToken cancellationToken)
    {
        var lastEmployee = await _context.Employees.OrderByDescending(o => o.Nik).FirstOrDefaultAsync(cancellationToken);
        return lastEmployee?.Nik ?? 18000;
    }
}