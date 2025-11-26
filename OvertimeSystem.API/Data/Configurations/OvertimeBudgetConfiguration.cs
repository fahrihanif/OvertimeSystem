using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class OvertimeBudgetConfiguration : IEntityTypeConfiguration<OvertimeBudget>
{
    public void Configure(EntityTypeBuilder<OvertimeBudget> builder)
    {
        builder.ToTable("tbl_overtime_budget");

        builder.Property(ob => ob.Id).HasColumnName("id");
        builder.Property(ob => ob.EmployeeId).HasColumnName("employee_id");
        builder.Property(ob => ob.BudgetMonth).HasColumnName("budget_month");
        builder.Property(ob => ob.InitialHours).HasColumnName("initial_hours");
        builder.Property(ob => ob.HoursConsumed).HasColumnName("hours_consumed");

        builder.HasIndex(ob => new { ob.EmployeeId, ob.BudgetMonth })
            .IsUnique();
    }
}