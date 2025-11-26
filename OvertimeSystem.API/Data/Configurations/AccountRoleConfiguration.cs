using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimeSystem.API.Models;

namespace OvertimeSystem.API.Data.Configurations;

public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
{
    public void Configure(EntityTypeBuilder<AccountRole> builder)
    {
        builder.ToTable("tbl_account_role");

        builder.Property(ar => ar.Id).HasColumnName("id");
        builder.Property(ar => ar.AccountId).HasColumnName("account_id");
        builder.Property(ar => ar.RoleId).HasColumnName("role_id");

        builder.HasIndex(ar => new { ar.AccountId, ar.RoleId })
            .IsUnique();
    }
}