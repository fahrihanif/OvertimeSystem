using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class OvertimePolicyRepository : Repository<OvertimePolicy>, IOvertimePolicyRepository
{
    public OvertimePolicyRepository(OvertimeSystemDbContext context) : base(context)
    {
    }

    public async Task<OvertimePolicy?> GetActivePolicyAsync(CancellationToken cancellationToken)
    {
        return await _context.OvertimePolicies
            .Where(o => o.IsActive == true)
            .FirstOrDefaultAsync(cancellationToken);
    }
}