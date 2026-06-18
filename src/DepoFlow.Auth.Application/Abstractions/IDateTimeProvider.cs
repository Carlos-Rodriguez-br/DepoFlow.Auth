namespace DepoFlow.Auth.Application.Abstractions;

public interface IDateTimeProvider
{
    DateTime CurrentTime { get; }
}