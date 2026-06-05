namespace DepoFlow.Auth.Domain.Users.ObjectValues;

public record UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
}