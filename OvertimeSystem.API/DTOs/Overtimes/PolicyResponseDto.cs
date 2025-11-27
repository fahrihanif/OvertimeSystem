namespace OvertimeSystem.API.DTOs.Overtimes;

public record PolicyResponseDto(
    Guid Id,
    string Name,
    ushort MaxDailyHours,
    ushort MaxWeeklyHours,
    TimeOnly WeekdayStartTime,
    TimeOnly WeekendStartTime,
    TimeOnly WeekendEndTime,
    bool IsActive
);