using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("tbl_employee");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Nik).HasColumnName("nik")
            .IsRequired();
        builder.Property(e => e.FirstName).HasColumnName("first_name")
            .HasMaxLength(50);
        builder.Property(e => e.LastName).HasColumnName("last_name")
            .HasMaxLength(50);
        builder.Property(e => e.Salary).HasColumnName("salary")
            .HasColumnType("decimal(18, 2)");
        builder.Property(e => e.Gender).HasColumnName("gender").HasConversion<string>().HasMaxLength(20);
        builder.Property(e => e.JoinedDate).HasColumnName("joined_date");
        builder.Property(e => e.Email).HasColumnName("email")
            .HasMaxLength(50);
        builder.Property(e => e.Position).HasColumnName("position")
            .HasMaxLength(50);
        builder.Property(e => e.Department).HasColumnName("department")
            .HasMaxLength(50);
        builder.Property(e => e.ManagerId).HasColumnName("manager_id");

        builder.HasIndex(e => e.Nik)
            .IsUnique();
    }
}