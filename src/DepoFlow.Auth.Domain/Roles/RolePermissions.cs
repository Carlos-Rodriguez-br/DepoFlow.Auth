using DepoFlow.Auth.Domain.Permissions.ObjectValues;
using DepoFlow.Auth.Domain.Roles.ObjectValues;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Roles;

public sealed class RolePermissions
{
    private RolePermissions()
    {
    }
    private RolePermissions(RoleId roleId, PermissionId permissionId)
    {
        PermissionId = permissionId;
        RoleId = roleId;
    }
    public PermissionId? PermissionId { get; private set; }
    public RoleId? RoleId { get; private set; }
    public static RolePermissions Create(RoleId roleId, PermissionId permissionId)
    {
        return new RolePermissions(
            roleId,
            permissionId
        );
    }
}