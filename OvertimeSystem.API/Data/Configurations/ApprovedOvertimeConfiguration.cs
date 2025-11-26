using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class ApprovedOvertimeConfiguration : IEntityTypeConfiguration<ApprovedOvertime>
{
    public void Configure(EntityTypeBuilder<ApprovedOvertime> builder)
    { 
        builder.ToTable("tbl_approved_overtime");
        
        builder.Property(ao => ao.Id).HasColumnName("id");
        builder.Property(ao => ao.RequestId).HasColumnName("request_id");
        builder.Property(ao => ao.RateId).HasColumnName("rate_id");
        builder.Property(ao => ao.TotalHours).HasColumnName("total_hours")
            .HasColumnType("smallint");
        builder.Property(ao => ao.CalculatedCost).HasColumnName("calculated_cost")
            .HasColumnType("decimal(18, 2)");
        builder.Property(ao => ao.Status).HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(20);    
    }
}