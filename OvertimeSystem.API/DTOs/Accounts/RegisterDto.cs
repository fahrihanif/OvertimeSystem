using OvertimeSystem.API.Enums;

namespace OvertimeSystem.API.DTOs.Accounts;

public record RegisterDto(
    string FirstName,
    string LastName,
    decimal Salary,
    GenderEnum Gender,
    DateTime JoinedDate,
    string Email,
    string Position,
    string Department,
    Guid? ManagerId,
    string Password,
    string ConfirmPassword
);