using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Commands.BookingConfirmation;
public record HotelBookingConfirmationRequest(
    string RateKey,
    string Remark,
    string FirstName,
    string LastName
    ) : IRequest<Result<HotelBookingConfirmationResponse.HotelBooking, Error>>;
