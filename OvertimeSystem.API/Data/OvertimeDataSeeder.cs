using OvertimeSystem.API.Enums;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data;

public static class OvertimeDataSeeder
{
    private static readonly Guid EmployeeId = new Guid("10000000-0000-0000-0000-000000000001");
    private static readonly Guid ManagerId = new Guid("10000000-0000-0000-0000-000000000002");
    private static readonly Guid AdminId = new Guid("10000000-0000-0000-0000-000000000003");
    
    private static readonly Guid PolicyId = new Guid("A0000000-0000-0000-0000-000000000001");
    
    public static List<Role> GetDefaultRoles()
    {
        return new List<Role>
        {
            new Role {Id = EmployeeId, Name = "Employee"},
            new Role {Id = ManagerId, Name = "Manager"},
            new Role {Id = AdminId, Name = "Admin"}
        };
    }

    public static List<OvertimePolicy> GetDefaultPolicies()
    {
        return new List<OvertimePolicy>
        {
            new OvertimePolicy
            {
                Id = PolicyId,
                PolicyName = "Standard",
                MaxDailyHours = 4,
                MaxWeeklyHours = 18,
                WeekdayStartTime = new TimeOnly(19, 0, 0),
                WeekendStartTime = new TimeOnly(9, 0, 0),
                WeekendEndTime = new TimeOnly(17, 0, 0),
                IsActive = true,
            }
        };
    }

    public static List<OvertimeRate> GetDefaultRates()
    {
        var rates = new List<OvertimeRate>();
        var baseDivisor = 173;
        
        // Normal Working Day Rates (1.5x, 2x)
        rates.Add(new OvertimeRate
        {
            Id = Guid.NewGuid(),
            RateName = "WD 1st Hr",
            DayType = OvertimeDayStatus.NORMAL,
            HourOrder = 1,
            Multiplier = 1.5m,
            BaseDivisor = baseDivisor,
        });
        
        rates.Add(new OvertimeRate
        {
            Id = Guid.NewGuid(),
            RateName = "WD 2nd+ Hr",
            DayType = OvertimeDayStatus.NORMAL,
            HourOrder = 2,
            Multiplier = 2.0m,
            BaseDivisor = baseDivisor,
        });
        
        // Weekend/Holiday Rates (2x, 3x, 4x)
        for (ushort i = 1; i <= 8; i++)
        {
            rates.Add(new OvertimeRate
            {
                Id = Guid.NewGuid(),
                RateName = $"WH Hr {i}",
                DayType = OvertimeDayStatus.WEEKEND_HOLIDAY,
                HourOrder = i,
                Multiplier = 2.0m,
                BaseDivisor = baseDivisor,
            });
        }
        
        rates.Add(new OvertimeRate
        {
            Id = Guid.NewGuid(),
            RateName = "WD Hr 9",
            DayType = OvertimeDayStatus.WEEKEND_HOLIDAY,
            HourOrder = 9,
            Multiplier = 3.0m,
            BaseDivisor = baseDivisor,
        });
        
        for (ushort i = 10; i <= 12; i++)
        {
            rates.Add(new OvertimeRate
            {
                Id = Guid.NewGuid(),
                RateName = $"WH Hr {i}",
                DayType = OvertimeDayStatus.WEEKEND_HOLIDAY,
                HourOrder = i,
                Multiplier = 4.0m,
                BaseDivisor = baseDivisor,
            });
        }
        
        return rates;
    }
}