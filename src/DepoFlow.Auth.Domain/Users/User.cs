using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Common;
using DepoFlow.Auth.Domain.Users.Events;
using DepoFlow.Auth.Domain.Users.ObjectValues;

namespace DepoFlow.Auth.Domain.Users;

public sealed class User : Entity<UserId>
{
    private User()
    {
    }
    private User(UserId id, UserName userName, FirstName firstName, LastName? lastName, Email email, PasswordHash passwordHash, Status isActive, DateTime createdAt, DateTime? updatedAt) : base(id)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    public UserName? UserName { get; private set; }
    public FirstName? FirstName { get; private set; }
    public LastName? LastName { get; private set; }
    public Email? Email { get; private set; }
    public PasswordHash? PasswordHash { get; private set; }
    public Status IsActive { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static User Create(UserName userName, FirstName firstName, LastName? lastName, Email email, PasswordHash passwordHash, DateTime createdAt)
    {
        var user = new User(UserId.New(), userName, firstName, lastName, email, passwordHash, Status.Active, createdAt, createdAt);
        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id!));
        return user;
    }
}