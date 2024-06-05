using HB.API.Extensions;
using HB.API.Shared;
using HB.Application.Features.Country.Commands.Create;
using HB.Application.Features.Country.Queries;

namespace HB.API.Endpoints;

public class CountryEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        const string TAG = "Country";

        app.MediatorGet<GetCountriesRequest, List<GetCountryResponse>>("country/list", TAG);
        app.MediatorGet<CreateCountryCommand, bool>("country", TAG);
    }
}
