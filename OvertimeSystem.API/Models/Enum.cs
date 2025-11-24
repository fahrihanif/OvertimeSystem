namespace OvertimeSystem.API.Models;

public enum OvertimeStatus
{
    Pending,
    Approved,
    Rejected,
    InfoRequired
}

public enum ApprovedOvertimeStatus
{
    PendingPayment,
    Paid
}

public enum OvertimeDay
{
    NORMAL,
    WEEKEND_HOLIDAY
}

public static class FixedGuids
{
    // Policies
    public static readonly Guid PolicyId = new Guid("A0000000-0000-0000-0000-000000000001");

    // Roles
    public static readonly Guid RoleEmployee = new Guid("10000000-0000-0000-0000-000000000001");
    public static readonly Guid RoleManager = new Guid("10000000-0000-0000-0000-000000000002");
    public static readonly Guid RoleAdmin = new Guid("10000000-0000-0000-0000-000000000003");
}