using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Repositories.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetByPosition(string position);
}