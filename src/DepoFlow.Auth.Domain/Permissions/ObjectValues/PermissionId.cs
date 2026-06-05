namespace DepoFlow.Auth.Domain.Permissions.ObjectValues;

public sealed record PermissionId(Guid Value)
{
    public static PermissionId New() => new(Guid.NewGuid());
}