namespace DepoFlow.Auth.Domain.Abstractions;

public class Entity<TEntityId> : IEntity
{
    public Entity()
    {
    }
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(TEntityId id)
    {
        Id = id;
    }
    public TEntityId? Id { get; init; }
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}