using HB.API.Shared;
using HB.Domain.Shared;
using MediatR;

namespace HB.API.Extensions;

internal static class MediatrExtensions
{
    internal static RouteHandlerBuilder MediatorGet<TRequest, TResponse>(this IEndpointRouteBuilder app, string route,
        string tag)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = $"/api/{route}";

        return app.MapGet(route, HandleGetRequests<TRequest, TResponse>)
            .WithGroupName("Main")
            .WithTags(tag)
            .Produces<TResponse>();
    }

    internal static RouteHandlerBuilder MediatorPost<TRequest, TResponse>(this IEndpointRouteBuilder app, string route, string tag)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = $"/api/{route}";

        return app.MapPost(route, HandlePostRequests<TRequest, TResponse>)
            .WithGroupName("Main")
            .WithTags(tag)
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
