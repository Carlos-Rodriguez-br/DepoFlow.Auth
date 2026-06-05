using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;