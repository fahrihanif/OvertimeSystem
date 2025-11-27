
using OvertimeSystem.API.DTOs.Overtimes;

namespace OvertimeSystem.API.Services.Interfaces;

public interface IOvertimeService
{
    Task OvertimeRequestAsync(OvertimeRequestDto request, CancellationToken cancellationToken);
}