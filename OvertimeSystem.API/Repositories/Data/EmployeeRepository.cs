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

    public async Task<IEnumerable<Employee>> GetByPosition(string position)
    {
        return await _context.Employees.Where(e => e.Position == position).ToListAsync();
    }
}