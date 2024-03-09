namespace HB.API.Shared;

public interface IEndpoint
{
    //void Register(WebApplication app);

    void MapEndpoint(IEndpointRouteBuilder app);
}
