using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data;

public class OvertimeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<OvertimePolicy> OvertimePolicies { get; set; }
    public DbSet<OvertimeRate> OvertimeRates { get; set; }
    public DbSet<OvertimeBudget> OvertimeBudgets { get; set; }
    public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
    public DbSet<ApprovedOvertime> ApprovedOvertime { get; set; }

    public OvertimeDbContext(DbContextOptions<OvertimeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- 1. Global Data Type and Index Configuration ---
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nik).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Nik).IsUnique();
        });
        
        modelBuilder.Entity<OvertimeRate>(entity =>
        {
            entity.Property(r => r.Multiplier).HasColumnType("decimal(4, 2)");
            entity.Property(r => r.DayType).HasConversion<string>().HasMaxLength(20);
        });
            
        modelBuilder.Entity<ApprovedOvertime>(entity =>
        {
            entity.Property(ao => ao.CalculatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(ao => ao.TotalHours).HasColumnType("smallint");
            entity.Property(ao => ao.Status).HasConversion<string>().HasMaxLength(20);
        });

        modelBuilder.Entity<OvertimeRequest>(entity =>
        {
            entity.Property(r => r.RequestedHours).HasColumnType("smallint");
            entity.Property(r => r.Status).HasConversion<string>().HasMaxLength(20);
            entity.Property(r => r.RequestType).HasConversion<string>().HasMaxLength(20);
        });
        
        modelBuilder.Entity<OvertimeBudget>(entity =>
        {
            entity.Property(ob => ob.InitialHours).HasColumnType("smallint");
            entity.Property(ob => ob.HoursConsumed).HasColumnType("smallint");
        });


        // --- 2. Relationship and Cardinality Configuration ---

        // Employee (Self-Referencing Manager)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(m => m.Subordinates)
            .HasForeignKey(e => e.ManagerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // Account (1-to-1 Relationship)
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account)
            .HasForeignKey<Account>(a => a.EmployeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // AccountRole (M-to-N Junction)
        modelBuilder.Entity<AccountRole>()
            .HasIndex(ar => new { ar.AccountId, ar.RoleId })
            .IsUnique();

        // OvertimeBudget
        modelBuilder.Entity<OvertimeBudget>()
            .HasIndex(ob => new { ob.EmployeeId, ob.BudgetMonth })
            .IsUnique();
        
        modelBuilder.Entity<OvertimeBudget>()
            .HasOne(ob => ob.Employee)
            .WithMany(e => e.OvertimeBudgets)
            .HasForeignKey(ob => ob.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // OvertimeRequest (M-to-1 relationships)
        modelBuilder.Entity<OvertimeRequest>()
            .HasOne(or => or.Employee).WithMany(e => e.OvertimeRequests).HasForeignKey(or => or.EmployeeId);
        modelBuilder.Entity<OvertimeRequest>()
            .HasOne(or => or.Policy).WithMany(p => p.OvertimeRequests).HasForeignKey(or => or.PolicyId).OnDelete(DeleteBehavior.Restrict);

        // ApprovedOvertime (1-to-1 Relationship)
        modelBuilder.Entity<ApprovedOvertime>()
            .HasOne(ao => ao.Request)
            .WithOne(r => r.ApprovedOvertime)
            .HasForeignKey<ApprovedOvertime>(ao => ao.RequestId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApprovedOvertime>()
            .HasOne(ao => ao.Rate)
            .WithMany(r => r.ApprovedOvertimeRecords)
            .HasForeignKey(ao => ao.RateId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- 3. Database Seeding for Constraints ---

        modelBuilder.Entity<Role>().HasData(OvertimeDataSeeder.GetDefaultRoles());
        modelBuilder.Entity<OvertimePolicy>().HasData(OvertimeDataSeeder.GetDefaultPolicies());
        modelBuilder.Entity<OvertimeRate>().HasData(OvertimeDataSeeder.GetDefaultRates());
    }
}