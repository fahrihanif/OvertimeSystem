using Microsoft.AspNetCore.Mvc;
using OvertimeSystem.API.DTOs.Overtimes;
using OvertimeSystem.API.Services.Interfaces;
using OvertimeSystem.API.Utilities;

namespace OvertimeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class OvertimePolicyController : ControllerBase
{
    private readonly IOvertimePolicyService _overtimePolicyService;

    public OvertimePolicyController(IOvertimePolicyService overtimePolicyService)
    {
        _overtimePolicyService = overtimePolicyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPolices(CancellationToken cancellationToken)
    {
        var policies = await _overtimePolicyService.GetAllPoliciesAsync(cancellationToken);
        
        return Ok(new ApiResponse<IEnumerable<PolicyResponseDto>>(policies));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicyById(Guid id, CancellationToken cancellationToken)
    {
        var policy = await _overtimePolicyService.GetPolicyByIdAsync(id, cancellationToken);
        
        return Ok(new ApiResponse<PolicyResponseDto>(policy));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePolicy(PolicyRequestDto request, CancellationToken cancellationToken)
    {
        await _overtimePolicyService.CreatePolicyAsync(request, cancellationToken);
        
        return Ok(new ApiResponse<object>("Policy Created"));
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePolicy(Guid id, PolicyRequestDto request, CancellationToken cancellationToken)
    {
        await _overtimePolicyService.UpdatePolicyAsync(id, request, cancellationToken);
        
        return Ok(new ApiResponse<object>("Policy Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(Guid id, CancellationToken cancellationToken)
    {
        await _overtimePolicyService.DeletePolicyAsync(id, cancellationToken);
        
        return Ok(new ApiResponse<object>("Policy Deleted"));
    }
}