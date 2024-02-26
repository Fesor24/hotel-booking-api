namespace HB.Domain.Shared;
public abstract class BaseError
{
    protected BaseError()
    {
        Code = "404";
        Message = "An error occurred";
        Details = "";
    }

    protected BaseError(string code, string message, string details)
    {
        Code = code;
        Message = message;
        Details = details;
    }

    public string Code { get; protected set; }
    public string Message { get; set; }
    public string Details { get; set; }
}
