using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class OvertimeRequestRepository : Repository<OvertimeRequest>, IOvertimeRequestRepository
{
    public OvertimeRequestRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}