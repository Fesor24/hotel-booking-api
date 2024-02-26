using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.CheckStatus;
public record CheckStatusRequest : IRequest<Result<HotelBedStatusResponse, Error>>; 
