namespace OvertimeSystem.API.DTOs.Overtimes;

public record PolicyRequestDto(
    string Name,
    ushort MaxDailyHours,
    ushort MaxWeeklyHours,
    TimeOnly WeekdayStartTime,
    TimeOnly WeekendStartTime,
    TimeOnly WeekendEndTime
);