namespace DepoFlow.Auth.Domain.Roles.ObjectValues;

public sealed record RoleId(Guid Value)
{
    public static RoleId New() => new(Guid.NewGuid());
}