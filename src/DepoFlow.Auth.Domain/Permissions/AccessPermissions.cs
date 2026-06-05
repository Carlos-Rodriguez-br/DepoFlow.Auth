using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;

namespace DepoFlow.Auth.Domain.Permissions;

public sealed class AccessPermissions : Entity<PermissionId>
{
    private AccessPermissions()
    {
    }
    private AccessPermissions(PermissionId id, ModuleId? moduleId, ActionId? actionId, string? key, string? description, bool isActive, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        ModuleId = moduleId;
        ActionId = actionId;
        Key = key;
        Description = description;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public ModuleId? ModuleId { get; private set; }
    public ActionId? ActionId { get; private set; }
    public string? Key { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static AccessPermissions Create(ModuleId moduleId, ActionId actionId, string key, string description, DateTime createdAt)
    {
        return new AccessPermissions(
            PermissionId.New(),
            moduleId, 
            actionId, 
            key, 
            description, 
            true, 
            createdAt, 
            createdAt
        );
    }
}