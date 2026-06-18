using DepoFlow.Auth.Domain.Permissions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class ModuleConfiguration : IEntityTypeConfiguration<Modules>
{
    public void Configure(EntityTypeBuilder<Modules> builder)
    {
        builder.ToTable("modules");
        builder.HasKey(module => module.Id);
        builder.Property(module => module.Id).HasConversion(moduleId => moduleId!.Value, value => new ModuleId(value));
        builder.Property(module => module.ParendModule).HasConversion(parentModuleId => parentModuleId!.Value, value => new ModuleId(value));
        builder.Property(module => module.Name).HasMaxLength(30);
        builder.Property(module => module.Description).HasMaxLength(150);
        builder.Property(module => module.Route).HasMaxLength(100);
        builder.Property(module => module.Icon).HasMaxLength(50);
    }
}