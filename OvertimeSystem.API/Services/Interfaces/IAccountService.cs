using OvertimeSystem.API.DTOs.Accounts;

namespace OvertimeSystem.API.Services.Interfaces;

public interface IAccountService
{
    Task RegisterAsync(RegisterDto request, CancellationToken cancellationToken);
    Task LoginAsync(LoginDto request, CancellationToken cancellationToken);
}