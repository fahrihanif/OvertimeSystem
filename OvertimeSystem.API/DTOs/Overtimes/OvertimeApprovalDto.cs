using OvertimeSystem.API.Enums;

namespace OvertimeSystem.API.DTOs.Overtimes;

public record OvertimeApprovalDto(
    Guid OvertimeId,
    OvertimeStatus status
);