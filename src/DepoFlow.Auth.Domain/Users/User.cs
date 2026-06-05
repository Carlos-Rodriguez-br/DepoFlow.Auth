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
    private User(UserId id, FirstName firstName, LastName? lastName, Email email, PasswordHash passwordHash, Status status, DateTime createdAt, DateTime? updatedAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public FirstName? FirstName { get; private set; }
    public LastName? LastName { get; private set; }
    public Email? Email { get; private set; }
    public PasswordHash? PasswordHash { get; private set; }
    public Status Status { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static User Create(FirstName firstName, LastName? lastName, Email email, PasswordHash passwordHash, DateTime createdAt)
    {
        var user = new User(UserId.New(), firstName, lastName, email, passwordHash, Status.Active, createdAt, createdAt);
        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id!));
        return user;
    }
}