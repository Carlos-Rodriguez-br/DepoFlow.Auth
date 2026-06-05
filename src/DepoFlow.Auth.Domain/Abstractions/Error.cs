namespace DepoFlow.Auth.Domain.Abstractions;

public record ErrorResult(string Code, string Name)
{
    public static readonly ErrorResult None = new(string.Empty, string.Empty);
    public static readonly ErrorResult NullValue = new("Error.NullValue", "Un valor Null fue ingresado");
}