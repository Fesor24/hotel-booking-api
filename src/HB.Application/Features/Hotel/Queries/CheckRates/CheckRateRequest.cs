using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.CheckRates;
public record CheckRateRequest(List<string> RateKeys) : IRequest<Result<HotelRateResponse.HotelRate, Error>>;
