using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Roles.ObjectValues;

namespace DepoFlow.Auth.Domain.Roles.Events;

public sealed record RoleCreatedDomainEvent(RoleId RoleId) : IDomainEvent;