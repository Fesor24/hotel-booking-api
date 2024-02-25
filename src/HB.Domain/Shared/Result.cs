namespace HB.Domain.Shared;
public class Result
{
    public Result()
    {
        IsSuccess = true;
        Error = Error.None;
    }

    public Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; private set; }
    public static Result Success => new();
}
