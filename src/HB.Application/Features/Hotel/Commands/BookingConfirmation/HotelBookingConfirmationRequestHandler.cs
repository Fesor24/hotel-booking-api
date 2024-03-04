using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Commands.BookingConfirmation;
internal sealed class HotelBookingConfirmationRequestHandler : IRequestHandler<HotelBookingConfirmationRequest,
    Result<HotelBookingConfirmationResponse.HotelBooking, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public HotelBookingConfirmationRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<HotelBookingConfirmationResponse.HotelBooking, Error>> 
        Handle(HotelBookingConfirmationRequest request, CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.ConfirmBooking(new Domain.Models.HotelBed.HotelBookingConfirmation
        {
            Remark = request.Remark,
            ClientReference = "IntegrationAgency",
            Holder = new Domain.Models.HotelBed.HotelBookingConfirmation.BookingHolder
            {
                Name = request.FirstName,
                Surname = request.LastName
            },
            Rooms = new List<Domain.Models.HotelBed.HotelBookingConfirmation.Room>
            {
                new Domain.Models.HotelBed.HotelBookingConfirmation.Room{RateKey =  request.RateKey}
            }
        });

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorDetails);
        }

        return res.Value.Booking;
    }
}
