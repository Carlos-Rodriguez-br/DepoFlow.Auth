using DepoFlow.Auth.Domain.Roles.ObjectValues;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Users;

public class UserRole
{
    private UserRole()
    {
    }
    private UserRole(UserId? userId, RoleId? roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public UserId? UserId { get; private set; }
    public RoleId? RoleId { get; private set; }
    public static UserRole Create(UserId userId, RoleId roleId)
    {
        return new UserRole(
            userId,
            roleId
        );
    }
}