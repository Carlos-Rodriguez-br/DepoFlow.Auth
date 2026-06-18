using DepoFlow.Auth.Domain.Permissions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;
using Microsoft.EntityFrameworkCore;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class AccessActionConfiguration : IEntityTypeConfiguration<AccessAction>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AccessAction> builder)
    {
        builder.ToTable("actions");
        builder.HasKey(action => action.Id);
        builder.Property(action => action.Id).HasConversion(actionId => actionId!.Value, value => new ActionId(value));
        builder.Property(action => action.Name).HasMaxLength(30);
        builder.Property(action => action.Description).HasMaxLength(150);
    }
}