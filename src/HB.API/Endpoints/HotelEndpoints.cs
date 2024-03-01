using HB.API.Extensions;
using HB.API.Shared;
using HB.Application.Features.Hotel.Queries.CheckStatus;
using HB.Application.Features.Hotel.Queries.Search;
using HB.Domain.Models.HotelBed;

namespace HB.API.Endpoints;

public class HotelEndpoints : IEndpoint
{
    public void Register(WebApplication app)
    {
        const string ENDPOINT = "Hotel";

        app.MediatorGet<CheckStatusRequest, HotelBedStatusResponse>(ENDPOINT, "status");
        app.MediatorPost<HotelSearchRequest, HotelSearchResponse>(ENDPOINT, "search");
    }
}
