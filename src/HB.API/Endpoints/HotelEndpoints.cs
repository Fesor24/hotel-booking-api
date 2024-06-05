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
        const string TAG = "Hotel";

        app.MediatorGet<CheckStatusRequest, HotelBedStatusResponse>("hotel/status", TAG);
        app.MediatorPost<HotelSearchRequest, SearchHotelResponse>("hotel/search", TAG);
        app.MediatorGet<GetHotelsRequest, List<Hotel>>("hotel/list", TAG);
        app.MediatorGet<GetLocationsRequest, List<HotelLocationResponse.Country>>("hotel/locations", TAG);
        app.MediatorPost<CheckRateRequest, HotelRateResponse.HotelRate>("hotel/rates", TAG);
        app.MediatorPost<HotelBookingConfirmationRequest, HotelBookingConfirmationResponse.HotelBooking>("hotel/booking", TAG);
        app.MediatorGet<GetFacilitiesRequest, object>("hotel/facilities", TAG);
        app.MediatorGet<CreateHotelsCommand, bool>("hotel/load", TAG);
    }
}
