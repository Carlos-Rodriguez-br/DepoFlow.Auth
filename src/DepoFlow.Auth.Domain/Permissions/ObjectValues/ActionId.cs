namespace DepoFlow.Auth.Domain.Permissions.ObjectValues;

public sealed record ActionId(Guid Value)
{
    public static ActionId New() => new(Guid.NewGuid());
}