using OvertimeSystem.API.Data;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories.Interfaces;

namespace OvertimeSystem.API.Repositories.Data;

public class ApprovedOvertimeRepository : Repository<ApprovedOvertime>, IApprovedOvertimeRepository
{
    public ApprovedOvertimeRepository(OvertimeSystemDbContext context) : base(context)
    {
    }
}