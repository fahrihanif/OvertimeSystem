using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class OvertimeRequestConfiguration : IEntityTypeConfiguration<OvertimeRequest>
{
    public void Configure(EntityTypeBuilder<OvertimeRequest> builder)
    {
        builder.ToTable("tbl_overtime_request");

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.EmployeeId).HasColumnName("employee_id");
        builder.Property(r => r.PolicyId).HasColumnName("policy_id");
        builder.Property(r => r.Date).HasColumnName("date");
        builder.Property(r => r.StartTime).HasColumnName("start_time");
        builder.Property(r => r.EndTime).HasColumnName("end_time");
        builder.Property(r => r.RequestedHours).HasColumnName("requested_hours")
            .HasColumnType("smallint");
        builder.Property(r => r.Status).HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(20);
        builder.Property(r => r.Comment).HasColumnName("comment").HasMaxLength(255);
        builder.Property(r => r.Timestamp).HasColumnName("timestamp");
        builder.Property(r => r.RequestType).HasColumnName("request_type")
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}