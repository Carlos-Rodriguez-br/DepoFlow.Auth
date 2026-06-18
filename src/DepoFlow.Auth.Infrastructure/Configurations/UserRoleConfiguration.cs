using DepoFlow.Auth.Domain.Roles.ObjectValues;
using DepoFlow.Auth.Domain.Users;
using DepoFlow.Auth.Domain.Users.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user-roles");
        builder.HasKey(x => new { x.RoleId, x.UserId });
        builder.Property(x => x.UserId).HasConversion(userId => userId!.Value, value => new UserId(value));
        builder.Property(x => x.RoleId).HasConversion(roleId => roleId!.Value, value => new RoleId(value));
    }
}