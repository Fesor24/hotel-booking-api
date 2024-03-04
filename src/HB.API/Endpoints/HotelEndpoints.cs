using HB.API.Extensions;
using HB.API.Shared;
using HB.Application.Features.Hotel.Commands.BookingConfirmation;
using HB.Application.Features.Hotel.Queries.CheckRates;
using HB.Application.Features.Hotel.Queries.CheckStatus;
using HB.Application.Features.Hotel.Queries.GetHotels;
using HB.Application.Features.Hotel.Queries.GetLocations;
using HB.Application.Features.Hotel.Queries.Search;
using HB.Domain.Models.HotelBed;

namespace HB.API.Endpoints;

public class HotelEndpoints : IEndpoint
{
    public void Register(WebApplication app)
    {
        const string ENDPOINT = "Hotel";

        app.MediatorGet<CheckStatusRequest, HotelBedStatusResponse>(ENDPOINT, "status");
        app.MediatorPost<HotelSearchRequest, HotelSearchResponse.HotelData>(ENDPOINT, "search");
        app.MediatorGet<GetHotelsRequest, object>(ENDPOINT, "");
        app.MediatorGet<GetLocationsRequest, HotelLocationResponse>(ENDPOINT, "locations");
        app.MediatorPost<CheckRateRequest, HotelRateResponse.HotelRate>(ENDPOINT, "rates");
        app.MediatorPost<HotelBookingConfirmationRequest, HotelBookingConfirmationResponse.HotelBooking>(ENDPOINT, "booking");
    }
}
