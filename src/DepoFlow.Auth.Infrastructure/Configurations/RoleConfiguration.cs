using DepoFlow.Auth.Domain.Roles;
using DepoFlow.Auth.Domain.Roles.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(role => role.Id);
        builder.Property(role => role.Id).HasConversion(roleId => roleId!.Value, value => new RoleId(value));
        builder.Property(role => role.Name).HasMaxLength(30);
        builder.Property(role => role.Description).HasMaxLength(150);
    }
}