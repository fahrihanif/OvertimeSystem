using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class OvertimeRateRepository : Repository<OvertimeRate>, IOvertimeRateRepsitory
{
    public OvertimeRateRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}