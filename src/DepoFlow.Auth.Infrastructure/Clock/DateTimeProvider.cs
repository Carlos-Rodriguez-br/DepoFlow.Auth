using DepoFlow.Auth.Application.Abstractions;

namespace DepoFlow.Auth.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}