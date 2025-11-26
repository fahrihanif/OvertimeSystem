using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class OvertimePolicyConfiguration : IEntityTypeConfiguration<OvertimePolicy>
{
    public void Configure(EntityTypeBuilder<OvertimePolicy> builder)
    {
        builder.ToTable("tbl_overtime_policy");

        builder.Property(op => op.Id).HasColumnName("id");
        builder.Property(op => op.PolicyName).HasColumnName("policy_name").HasMaxLength(50);
        builder.Property(op => op.MaxDailyHours).HasColumnName("max_daily_hours");
        builder.Property(op => op.MaxWeeklyHours).HasColumnName("max_weekly_hours");
        builder.Property(op => op.WeekdayStartTime).HasColumnName("weekday_start_time");
        builder.Property(op => op.WeekendStartTime).HasColumnName("weekend_start_time");
        builder.Property(op => op.WeekendEndTime).HasColumnName("weekend_end_time");
        builder.Property(op => op.IsActive).HasColumnName("is_active");
    }
}