using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data;

public class OvertimeSystemDbContext(DbContextOptions<OvertimeSystemDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<ApprovedOvertime> ApprovedOvertimes { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<OvertimeBudget> OvertimeBudgets { get; set; }
    public DbSet<OvertimePolicy> OvertimePolicies { get; set; }
    public DbSet<OvertimeRate> OvertimeRates { get; set; }
    public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- 1. Global Data Type and Index Configuration ---
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // --- 2. Relationship and Cardinality Configuration ---
        // Employee (Self-Referencing Manager)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(m => m.Employees)
            .HasForeignKey(e => e.ManagerId);
        
        // 1 Account to 1 Employee
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account)
            .HasForeignKey<Account>(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // 1 Account to Many AccountRole
        modelBuilder.Entity<AccountRole>()
            .HasOne(ar => ar.Account)
            .WithMany(a => a.AccountRoles)
            .HasForeignKey(ar => ar.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Many AccountRole to 1 Role
        modelBuilder.Entity<AccountRole>()
            .HasOne(ar => ar.Role)
            .WithMany(r => r.AccountRoles)
            .HasForeignKey(ar => ar.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // 1 Employee to Many OvertimeBudget
        modelBuilder.Entity<OvertimeBudget>()
            .HasOne(ob => ob.Employee)
            .WithMany(e => e.OvertimeBudgets)
            .HasForeignKey(ob => ob.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // 1 Employee with Many OvertimeRequest
        modelBuilder.Entity<OvertimeRequest>()
            .HasOne(or => or.Employee)
            .WithMany(e => e.OvertimeRequests)
            .HasForeignKey(or => or.EmployeeId);
        
        // 1 Policy with Many OvertimeRequest
        modelBuilder.Entity<OvertimeRequest>()
            .HasOne(or => or.Policy)
            .WithMany(p => p.OvertimeRequests)
            .HasForeignKey(or => or.PolicyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // 1 OvertimeRequest to 1 ApprovedOvertime
        modelBuilder.Entity<ApprovedOvertime>()
            .HasOne(ao => ao.Request)
            .WithOne(r => r.ApprovedOvertime)
            .HasForeignKey<ApprovedOvertime>(ao => ao.RequestId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // 1 Rate with Many ApprovedOvertime
        modelBuilder.Entity<ApprovedOvertime>()
            .HasOne(ao => ao.Rate)
            .WithMany(or => or.ApprovedOvertimes)
            .HasForeignKey(ao => ao.RateId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // --- 3. Database Seeding for Constraints ---
        modelBuilder.Entity<Role>().HasData(OvertimeDataSeeder.GetDefaultRoles());
        modelBuilder.Entity<OvertimeRate>().HasData(OvertimeDataSeeder.GetDefaultRates());
        modelBuilder.Entity<OvertimePolicy>().HasData(OvertimeDataSeeder.GetDefaultPolicies());
    }
}