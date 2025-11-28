using OvertimeSystem.API.DTOs.Overtimes;
using OvertimeSystem.API.Enums;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories;
using OvertimeSystem.API.Repositories.Interfaces;
using OvertimeSystem.API.Services.Interfaces;

namespace OvertimeSystem.API.Services;

public class OvertimeService : IOvertimeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IOvertimePolicyRepository _overtimePolicyRepository;
    private readonly IOvertimeRequestRepository _overtimeRequestRepository;
    private readonly IOvertimeBudgetRepository _overtimeBudgetRepository;

    private readonly IUnitOfWork _unitOfWork;

    public OvertimeService(IOvertimePolicyRepository overtimePolicyRepository,
        IOvertimeBudgetRepository overtimeBudgetRepository, IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork, IOvertimeRequestRepository overtimeRequestRepository)
    {
        _overtimePolicyRepository = overtimePolicyRepository;
        _overtimeBudgetRepository = overtimeBudgetRepository;
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
        _overtimeRequestRepository = overtimeRequestRepository;
    }

    public async Task OvertimeRequestAsync(OvertimeRequestDto request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee is null)
        {
            throw new NullReferenceException("Employee not found");
        }
        await _unitOfWork.ClearTracksAsync(cancellationToken);

        var requestedHours = Convert.ToUInt16(request.EndTime - request.StartTime);
        if (requestedHours > 4)
        {
            throw new ArgumentException("Requested hours must be less than 4 hours per day");
        }
        
        var defaultPolicy = await _overtimePolicyRepository.GetActivePolicyAsync(cancellationToken);
        if (defaultPolicy is null)
        {
            throw new NullReferenceException("Default policy not found");
        }
        var requestType = GetOvertimeDayStatus(request.Date);
        if (requestType == OvertimeDayStatus.NORMAL)
        {
            if (request.StartTime < defaultPolicy.WeekdayStartTime)
                throw new ArgumentException($"Overtime on weekdays must start at or after {defaultPolicy.WeekdayStartTime}.");
        }
        if (requestType == OvertimeDayStatus.WEEKEND_HOLIDAY)
        {
            if (request.StartTime < defaultPolicy.WeekendStartTime || request.EndTime > defaultPolicy.WeekendEndTime)
                throw new ArgumentException($"Overtime on weekends must be between {defaultPolicy.WeekendStartTime} and {defaultPolicy.WeekendEndTime}.");
        }
        
        var getMonthFirstDate = GetMonthFirstDate(request.Date);
        var overtimeBudget = await _overtimeBudgetRepository.GetActiveBudgetAsync(employee.Id, getMonthFirstDate, cancellationToken);
        await _unitOfWork.ClearTracksAsync(cancellationToken);

        if (overtimeBudget is null)
        {
            overtimeBudget!.Id = Guid.NewGuid();
            overtimeBudget.EmployeeId = employee.Id;
            overtimeBudget.BudgetMonth = getMonthFirstDate;
            overtimeBudget.InitialHours = 40;
            overtimeBudget.HoursConsumed = 40;
            
            await _unitOfWork.CommitTransactionAsync(
                async () =>
                {
                    await _overtimeBudgetRepository.CreateAsync(overtimeBudget, cancellationToken);
                },
                cancellationToken);
        }

        if (Convert.ToInt16(overtimeBudget.HoursConsumed - requestedHours) < 0)
        {
            throw new ArgumentException($"Requested hours ({requestedHours}) exceed the remaining monthly budget ({overtimeBudget.HoursConsumed} hours).");
        }
        
        overtimeBudget.HoursConsumed -= requestedHours;

        var overtimeRequest = new OvertimeRequest
        {
            Id = Guid.NewGuid(),
            EmployeeId = employee.Id,
            PolicyId = defaultPolicy.Id,
            Date = request.Date,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            RequestedHours = requestedHours,
            Status = OvertimeStatus.Pending,
            Comment = request.Comment,
            RequestType = requestType,
        };

        await _unitOfWork.CommitTransactionAsync(
            async () =>
            {
                await _overtimeRequestRepository.CreateAsync(overtimeRequest, cancellationToken);
                await _overtimeBudgetRepository.UpdateAsync(overtimeBudget);
            },
            cancellationToken);
    }

    public Task OvertimeApprovalAsync(OvertimeApprovalDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private OvertimeDayStatus GetOvertimeDayStatus(DateOnly date)
    {
        int day = (int)date.DayOfWeek;
        if (day == 0 || day == 6)
        {
            return OvertimeDayStatus.WEEKEND_HOLIDAY;
        }

        return OvertimeDayStatus.NORMAL;
    }

    private DateTime GetMonthFirstDate(DateOnly date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }
}