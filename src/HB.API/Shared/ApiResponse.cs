using HB.Domain.Shared;

namespace HB.API.Shared;

public class ApiResponse
{
    public ApiResponse()
    {
        IsSuccess = true;
    }

    public ApiResponse(Error error)
    {
        Error = error;
        IsSuccess = false;
    }

    public bool IsSuccess { get; private set; }

    public Error Error { get; set; }

    public static ApiResponse Success => new();

}

public class ApiResponse<TResponse> : ApiResponse
{
    public ApiResponse(TResponse response) : base()
    {
        Data = response;
    }

    public TResponse Data { get; set; }

    public static implicit operator ApiResponse<TResponse>(TResponse response) => new(response);
}
