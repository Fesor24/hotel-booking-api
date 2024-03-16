using HB.API.Extensions;
using HB.API.Shared;
using HB.Application.Features.Hotel.Commands.BookingConfirmation;
using HB.Application.Features.Hotel.Commands.Create;
using HB.Application.Features.Hotel.Queries.CheckRates;
using HB.Application.Features.Hotel.Queries.CheckStatus;
using HB.Application.Features.Hotel.Queries.GetFacilities;
using HB.Application.Features.Hotel.Queries.GetHotels;
using HB.Application.Features.Hotel.Queries.GetLocations;
using HB.Application.Features.Hotel.Queries.Search;
using HB.Domain.Entity.HotelAggregate;
using HB.Domain.Models.HotelBed;

namespace HB.API.Endpoints;

public class HotelEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        const string ENDPOINT = "Hotel";

        app.MediatorGet<CheckStatusRequest, HotelBedStatusResponse>(ENDPOINT, "status");
        app.MediatorPost<HotelSearchRequest, SearchHotelResponse>(ENDPOINT, "search");
        app.MediatorGet<GetHotelsRequest, List<Hotel>>(ENDPOINT, "list");
        app.MediatorGet<GetLocationsRequest, List<HotelLocationResponse.Country>>(ENDPOINT, "locations");
        app.MediatorPost<CheckRateRequest, HotelRateResponse.HotelRate>(ENDPOINT, "rates");
        app.MediatorPost<HotelBookingConfirmationRequest, HotelBookingConfirmationResponse.HotelBooking>(ENDPOINT, "booking");
        app.MediatorGet<GetFacilitiesRequest, object>(ENDPOINT, "facilities");
        app.MediatorGet<CreateHotelsCommand, bool>(ENDPOINT, "load");
    }
}
