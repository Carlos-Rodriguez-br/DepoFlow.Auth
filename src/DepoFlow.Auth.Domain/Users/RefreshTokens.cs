using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Users.Events;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Users;

public sealed class RefreshTokens : Entity<RefreshTokenId>
{
    private RefreshTokens()
    {
    }

    private RefreshTokens(RefreshTokenId id, UserId userId, Token token, DateTime expiresAt, DateTime? revokedAt, DateTime createdAt) : base(id)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        RevokedAt = revokedAt;
        CreatedAt = createdAt;
    }

    public UserId? UserId { get; private set; }
    public Token? Token { get; private set; }
    public DateTime? ExpiresAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public static RefreshTokens Create(UserId userId, Token token, DateTime expiresAt, DateTime createdAt)
    {
        var refreshToken = new RefreshTokens(RefreshTokenId.New(), userId, token, expiresAt, null, createdAt);
        refreshToken.AddDomainEvent(new RefreshTokenCreatedDomainEvent(refreshToken.Id!));
        return refreshToken;
    }
}