using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Repositories.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<int> GetLastEmployeeId(CancellationToken cancellationToken);
}