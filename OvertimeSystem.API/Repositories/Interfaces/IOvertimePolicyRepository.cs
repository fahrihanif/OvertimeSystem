using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Repositories.Interfaces;

public interface IOvertimePolicyRepository : IRepository<OvertimePolicy>
{
    Task<OvertimePolicy?> GetActivePolicyAsync(CancellationToken cancellationToken);
}