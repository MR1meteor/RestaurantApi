namespace Restaurant.Application.Domain.Errors;

public class Result<T>
{
    private Result(bool isSuccess, Error error, T? data)
    {
        if ((!isSuccess && error == Error.None) ||
            (isSuccess && error != Error.None))
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }

    public bool IsSuccess { get; }
    public Error Error { get; }
    public T? Data { get; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, Error.None, data);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(false, error, default);
    }
}