using HB.Domain.Models.Http;
using HB.Domain.Shared;

namespace HB.Domain.Services.Http;
public interface IHttpClient
{
    Task<Result<TResult, TErrorResult>> SendAsync<TBody, TResult, TErrorResult>(HttpRequest<TBody> model)
        where TErrorResult : BaseError;
    Task<Result<TResult, TErrorResult>> SendAsync<TResult, TErrorResult>(HttpRequest model)
        where TErrorResult : BaseError;
}
