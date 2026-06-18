using DepoFlow.Auth.Domain.Permissions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class AccessPermissionConfiguration : IEntityTypeConfiguration<AccessPermissions>
{
    public void Configure(EntityTypeBuilder<AccessPermissions> builder)
    {
        builder.ToTable("permissions");
        builder.HasKey(permission => permission.Id);
        builder.Property(permission => permission.Id).HasConversion(permissionId => permissionId!.Value, value => new PermissionId(value));
        builder.Property(permission => permission.ModuleId).HasConversion(moduleId => moduleId!.Value, value => new ModuleId(value));
        builder.Property(permission => permission.ActionId).HasConversion(actionId => actionId!.Value, value => new ActionId(value));
        builder.Property(permission => permission.Key).HasMaxLength(30);
        builder.Property(permission => permission.Description).HasMaxLength(150);
    }
}