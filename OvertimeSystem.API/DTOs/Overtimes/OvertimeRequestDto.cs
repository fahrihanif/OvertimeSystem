namespace OvertimeSystem.API.DTOs.Overtimes;

public record OvertimeRequestDto
(
    Guid EmployeeId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Comment
);