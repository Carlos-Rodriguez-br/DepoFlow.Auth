using MediatR;

namespace DepoFlow.Auth.Domain.Abstractions;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface used to identify domain events in MediatR pipeline.")]
public interface IDomainEvent : INotification
{
}