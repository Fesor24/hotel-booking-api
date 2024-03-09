using HB.API.Shared;
using HB.Domain.Shared;
using MediatR;

namespace HB.API.Extensions;

internal static class MediatrExtensions
{
    internal static void MediatorGet<TRequest, TResponse>(this IEndpointRouteBuilder app, 
        string endpointGroup, string route)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = $"/api/{endpointGroup}/{route}";

        app.MapGet(route, HandleGetRequests<TRequest, TResponse>)
            .WithGroupName(endpointGroup)
            .Produces<TResponse>();
    }

    internal static void MediatorPost<TRequest, TResponse>(this IEndpointRouteBuilder app, 
        string endpointGroup, string route)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = $"/api/{endpointGroup}/{route}";

        app.MapPost(route, HandlePostRequests<TRequest, TResponse>)
            .WithGroupName(endpointGroup)
            .Produces<TResponse>();
    }

    private static async Task<IResult> HandleGetRequests<TRequest, TResponse>(ISender sender, 
        [AsParameters]TRequest request)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        var res = await sender.Send(request);

        return res.Match(val => Results.Ok(new ApiResponse<TResponse>(val)), 
            err => Results.BadRequest(new ApiResponse(err)));
    }

    private static async Task<IResult> HandlePostRequests<TRequest, TResponse>(ISender sender,
        TRequest request)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        var res = await sender.Send(request);

        return res.Match(val => Results.Ok(new ApiResponse<TResponse>(val)),
            err => Results.BadRequest(new ApiResponse(err)));
    }
}
