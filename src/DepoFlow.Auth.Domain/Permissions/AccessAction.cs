using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;

namespace DepoFlow.Auth.Domain.Permissions;

public sealed class AccessAction : Entity<ActionId>
{
    private AccessAction()
    {
    }

    public AccessAction(ActionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public static AccessAction Create(string name, string description)
    {
        return new AccessAction(ActionId.New(), name, description);
    }
}