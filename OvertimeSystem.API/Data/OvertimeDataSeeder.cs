using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data;

public static class OvertimeDataSeeder
{
    // --- ROLES ---
    public static List<Role> GetDefaultRoles()
    {
        return new List<Role>
        {
            new Role { Id = FixedGuids.RoleEmployee, Name = "Employee" },
            new Role { Id = FixedGuids.RoleManager, Name = "Manager" },
            new Role { Id = FixedGuids.RoleAdmin, Name = "Admin" }
        };
    }

    // --- POLICIES ---
    public static List<OvertimePolicy> GetDefaultPolicies()
    {
        return new List<OvertimePolicy>
        {
            new OvertimePolicy
            {
                Id = FixedGuids.PolicyId,
                PolicyName = "Standard Labor Law Compliance",
                MaxDailyHours = 4,
                MaxWeeklyHours = 18,
                WeekdayStartTime = new TimeSpan(19, 0, 0),
                WeekendStartTime = new TimeSpan(9, 0, 0),
                WeekendEndTime = new TimeSpan(17, 0, 0),
                IsActive = true
            }
        };
    }

    // --- RATES ---
    public static List<OvertimeRate> GetDefaultRates()
    {
        var rates = new List<OvertimeRate>();
        var baseDivisor = 173;
        
        // 1. Normal Working Day Rates (1.5x, 2x)
        rates.Add(new OvertimeRate { Id = Guid.NewGuid(), RateName = "WD 1st Hr", DayType = OvertimeDay.NORMAL, HourOrder = 1, Multiplier = 1.5m, BaseDivisor = baseDivisor });
        rates.Add(new OvertimeRate { Id = Guid.NewGuid(), RateName = "WD 2nd+ Hr", DayType = OvertimeDay.NORMAL, HourOrder = 2, Multiplier = 2.0m, BaseDivisor = baseDivisor });

        // 2. Weekend/Standard Holiday Rates (2x, 3x, 4x)
        for (short i = 1; i <= 8; i++)
            rates.Add(new OvertimeRate { Id = Guid.NewGuid(), RateName = $"WH Hr {i}", DayType = OvertimeDay.WEEKEND_HOLIDAY, HourOrder = i, Multiplier = 2.0m, BaseDivisor = baseDivisor });
        
        rates.Add(new OvertimeRate { Id = Guid.NewGuid(), RateName = "WH Hr 9", DayType = OvertimeDay.WEEKEND_HOLIDAY, HourOrder = 9, Multiplier = 3.0m, BaseDivisor = baseDivisor });
        
        for (short i = 10; i <= 12; i++)
            rates.Add(new OvertimeRate { Id = Guid.NewGuid(), RateName = $"WH Hr {i}", DayType = OvertimeDay.WEEKEND_HOLIDAY, HourOrder = i, Multiplier = 4.0m, BaseDivisor = baseDivisor });
            
        return rates;
    }
}