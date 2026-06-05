using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Users.Events;

public sealed record RefreshTokenCreatedDomainEvent(RefreshTokenId RefreshTokenId) : IDomainEvent;