using OvertimeSystem.API.DTOs.Overtimes;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories;
using OvertimeSystem.API.Repositories.Interfaces;
using OvertimeSystem.API.Services.Interfaces;

namespace OvertimeSystem.API.Services;

public class OvertimePolicyService : IOvertimePolicyService
{
    private readonly IOvertimePolicyRepository _overtimePolicyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OvertimePolicyService(IOvertimePolicyRepository overtimePolicyRepository, IUnitOfWork unitOfWork)
    {
        _overtimePolicyRepository = overtimePolicyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreatePolicyAsync(PolicyRequestDto requestDto, CancellationToken cancellationToken)
    {
        var policy = new OvertimePolicy
        {
            Id = Guid.NewGuid(),
            PolicyName = requestDto.Name,
            MaxDailyHours = requestDto.MaxDailyHours,
            MaxWeeklyHours = requestDto.MaxWeeklyHours,
            WeekdayStartTime = requestDto.WeekdayStartTime,
            WeekendStartTime = requestDto.WeekendStartTime,
            WeekendEndTime = requestDto.WeekendEndTime,
            IsActive = false
        };
        
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _overtimePolicyRepository.CreateAsync(policy, cancellationToken);
        }, cancellationToken);
    }

    public async Task UpdatePolicyAsync(Guid id, PolicyRequestDto requestDto, CancellationToken cancellationToken)
    {
        var policy = await _overtimePolicyRepository.GetByIdAsync(id, cancellationToken);

        if (policy is null)
        {
            throw new NullReferenceException("Policy Id not found");
        }
        
        policy.PolicyName = requestDto.Name;
        policy.MaxDailyHours = requestDto.MaxDailyHours;
        policy.MaxWeeklyHours = requestDto.MaxWeeklyHours;
        policy.WeekdayStartTime = requestDto.WeekdayStartTime;
        policy.WeekendStartTime = requestDto.WeekendStartTime;
        policy.WeekendEndTime = requestDto.WeekendEndTime;
        
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _overtimePolicyRepository.UpdateAsync(policy);
        }, cancellationToken);
    }

    public async Task DeletePolicyAsync(Guid id, CancellationToken cancellationToken)
    {
        var policy = await _overtimePolicyRepository.GetByIdAsync(id, cancellationToken);

        if (policy is null)
        {
            throw new NullReferenceException("Policy Id not found");
        }
        
        await _unitOfWork.ClearTracksAsync(cancellationToken);
        
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _overtimePolicyRepository.DeleteAsync(policy);
        }, cancellationToken);
    }

    public async Task<IEnumerable<PolicyResponseDto>> GetAllPoliciesAsync(CancellationToken cancellationToken)
    {
        var getPolicies = await _overtimePolicyRepository.GetAllAsync(cancellationToken);

        if (!getPolicies.Any())
        {
            throw new NullReferenceException("No policies found");
        }

        var policiesMap = getPolicies.Select(p => new PolicyResponseDto(
                p.Id,
                p.PolicyName,
                p.MaxDailyHours,
                p.MaxWeeklyHours,
                p.WeekdayStartTime,
                p.WeekendStartTime,
                p.WeekendEndTime,
                p.IsActive
            ));
        
        return policiesMap;
    }

    public async Task<PolicyResponseDto> GetPolicyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var getPolicy = await _overtimePolicyRepository.GetByIdAsync(id, cancellationToken);

        if (getPolicy is null)
        {
           throw new NullReferenceException("Policy Id not found");
        }

        var policyMap = new PolicyResponseDto(
            getPolicy.Id,
            getPolicy.PolicyName,
            getPolicy.MaxDailyHours,
            getPolicy.MaxWeeklyHours,
            getPolicy.WeekdayStartTime,
            getPolicy.WeekendStartTime,
            getPolicy.WeekendEndTime,
            getPolicy.IsActive
        );
        
        return policyMap;
    }

    public async Task ChangePolicyStatusAsync(Guid id, bool status, CancellationToken cancellationToken)
    {
        var getPolicy = await _overtimePolicyRepository.GetByIdAsync(id, cancellationToken);

        if (getPolicy is null)
        {
            throw new NullReferenceException("Policy Id not found");
        }
        await _unitOfWork.ClearTracksAsync(cancellationToken);
        
        getPolicy.IsActive = status;

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _overtimePolicyRepository.UpdateAsync(getPolicy);
        }, cancellationToken);
    }
}