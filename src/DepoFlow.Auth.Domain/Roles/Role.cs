using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Common;
using DepoFlow.Auth.Domain.Roles.Events;
using DepoFlow.Auth.Domain.Roles.ObjectValues;

namespace DepoFlow.Auth.Domain.Roles;

public sealed class Role : Entity<RoleId>
{
    private Role()
    {
    }

    private Role(RoleId id, Name? name, Description? description, Status? status, DateTime? createdAt, DateTime? updatedAt): base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Name? Name { get; private set; }
    public Description? Description { get; private set; }
    public Status? Status { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static Role Create(Name name, Description description, Status status, DateTime createdAt)
    {
        var role = new Role(RoleId.New(), name, description, status, createdAt, createdAt);
        role.AddDomainEvent(new RoleCreatedDomainEvent(role.Id!));
        return role;
    }

}