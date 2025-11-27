using OvertimeSystem.API.DTOs.Accounts;
using OvertimeSystem.API.Models;
using OvertimeSystem.API.Repositories;
using OvertimeSystem.API.Repositories.Interfaces;
using OvertimeSystem.API.Services.Interfaces;

namespace OvertimeSystem.API.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IOvertimeBudgetRepository _overtimeBudgetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IOvertimeBudgetRepository overtimeBudgetRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
        _overtimeBudgetRepository = overtimeBudgetRepository;
    }

    public async Task RegisterAsync(RegisterDto request, CancellationToken cancellationToken)
    {
        var getLastEmployeeNik = await _employeeRepository.GetLastEmployeeId(cancellationToken);
        await _unitOfWork.ClearTracksAsync(cancellationToken);

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Nik = GenerateNIK(getLastEmployeeNik),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Salary = request.Salary,
            Gender = request.Gender,
            JoinedDate = request.JoinedDate,
            Email = request.Email,
            Position = request.Position,
            Department = request.Department,
            ManagerId = request.ManagerId,
        };

        var account = new Account
        {
            EmployeeId = employee.Id,
            Password = request.Password,
            Otp = 929292,
            Expired = DateTime.Now,
            IsActive = true,
            IsUsed = true
        };

        var overtimeBudget = new OvertimeBudget
        {
            Id = Guid.NewGuid(),
            EmployeeId = employee.Id,
            BudgetMonth = GetCurrentMonthDate(),
            InitialHours = 40,
            HoursConsumed = 40
        };

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _employeeRepository.CreateAsync(employee, cancellationToken);
            await _accountRepository.CreateAsync(account, cancellationToken);
            await _overtimeBudgetRepository.CreateAsync(overtimeBudget, cancellationToken);
        }, cancellationToken);
    }

    public async Task LoginAsync(LoginDto request, CancellationToken cancellationToken)
    {
        
    }

    private int GenerateNIK(int lastEmployeeId)
    {
        return lastEmployeeId + 1;
    }

    private DateTime GetCurrentMonthDate()
    {
        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    }
}