namespace DepoFlow.Auth.Domain.Permissions.ObjectValues;

public sealed record ModuleId(Guid Value)
{
    public static ModuleId New() => new(Guid.NewGuid());
}