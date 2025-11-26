using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("tbl_account");

        builder.HasKey(a => a.EmployeeId);

        builder.Property(a => a.EmployeeId).HasColumnName("employee_id");
        builder.Property(a => a.Password).HasColumnName("password").HasMaxLength(255);
        builder.Property(a => a.Otp).HasColumnName("otp");
        builder.Property(a => a.Expired).HasColumnName("expired");
        builder.Property(a => a.IsUsed).HasColumnName("is_used");
        builder.Property(a => a.IsActive).HasColumnName("is_active");
    }
}