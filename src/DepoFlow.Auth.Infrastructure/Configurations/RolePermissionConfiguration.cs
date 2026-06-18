using DepoFlow.Auth.Domain.Permissions.ObjectValues;
using DepoFlow.Auth.Domain.Roles;
using DepoFlow.Auth.Domain.Roles.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissions>
{
    public void Configure(EntityTypeBuilder<RolePermissions> builder)
    {
        builder.ToTable("role_permissions");
        builder.HasKey(x => new { x.RoleId, x.PermissionId });
        builder.Property(x => x.RoleId)
            .HasConversion(roleId => roleId!.Value, value => new RoleId(value));
        builder.Property(x => x.PermissionId)
            .HasConversion(permissionId => permissionId!.Value, value => new PermissionId(value));
    }
}