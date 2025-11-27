using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Repositories.Interfaces;

public interface IOvertimeBudgetRepository : IRepository<OvertimeBudget>
{
    Task<OvertimeBudget?> GetActiveBudgetAsync(Guid employeeId, DateTime date, CancellationToken cancellationToken);
}