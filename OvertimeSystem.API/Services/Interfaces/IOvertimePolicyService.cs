using OvertimeSystem.API.DTOs.Overtimes;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Services.Interfaces;

public interface IOvertimePolicyService
{
    Task CreatePolicyAsync(PolicyRequestDto requestDto, CancellationToken cancellationToken);
    Task UpdatePolicyAsync(Guid id, PolicyRequestDto requestDto, CancellationToken cancellationToken);
    Task DeletePolicyAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<PolicyResponseDto>> GetAllPoliciesAsync(CancellationToken cancellationToken);
    Task<PolicyResponseDto> GetPolicyByIdAsync(Guid id, CancellationToken cancellationToken);
    Task ChangePolicyStatusAsync(Guid id, bool status, CancellationToken cancellationToken);
}