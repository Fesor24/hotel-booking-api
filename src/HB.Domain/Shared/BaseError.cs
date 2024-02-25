namespace HB.Domain.Shared;
public abstract class BaseError
{
    protected BaseError()
    {
        Code = "404";
        Message = "An error occurred";
    }

    protected BaseError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; protected set; }
    public string Message { get; set; }
}
