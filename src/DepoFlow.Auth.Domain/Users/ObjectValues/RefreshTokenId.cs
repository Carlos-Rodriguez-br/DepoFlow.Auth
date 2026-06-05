namespace DepoFlow.Auth.Domain.Users.ObjectValues;

public sealed record RefreshTokenId(Guid Value)
{
    public static RefreshTokenId New() => new(Guid.NewGuid());
}