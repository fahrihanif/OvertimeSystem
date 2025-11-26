using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class OvertimeRateConfiguration :  IEntityTypeConfiguration<OvertimeRate>
{
    public void Configure(EntityTypeBuilder<OvertimeRate> builder)
    {
        builder.ToTable("tbl_overtime_rate");

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.RateName).HasColumnName("rate_name").HasMaxLength(50);
        builder.Property(r => r.DayType).HasColumnName("day_type")
            .HasConversion<string>().HasMaxLength(20);
        builder.Property(r => r.HourOrder).HasColumnName("hour_order");
        builder.Property(r => r.Multiplier).HasColumnName("multiplier")
            .HasColumnType("decimal(4, 2)");
        builder.Property(r => r.BaseDivisor).HasColumnName("base_divisor");
    }
}