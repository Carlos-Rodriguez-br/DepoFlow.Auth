using System.Diagnostics.CodeAnalysis;

namespace DepoFlow.Auth.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, ErrorResult error)
    {
        if(isSuccess && error != ErrorResult.None)
        {
            throw new InvalidOperationException();
        }

        if(!isSuccess  && error == ErrorResult.None )
        {
            throw new InvalidOperationException();
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess {get;}
    public bool IsFailure => !IsSuccess;
    public ErrorResult Error {get;}

    public static Result Success() => new(true, ErrorResult.None);

    public static Result Failure(ErrorResult error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) 
        => new(value, true, ErrorResult.None);


    public static Result<TValue> Failure<TValue>(ErrorResult error) 
        => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) 
        => value is not null 
        ? Success(value) 
        : Failure<TValue>(ErrorResult.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, ErrorResult error) 
    : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSuccess
    ? _value!
    : throw new InvalidOperationException("El resultado del valor de error no es admisible");

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}