using HB.Domain.Entity.HotelAggregate;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetHotels;
internal sealed class GetHotelsRequestHandler : IRequestHandler<GetHotelsRequest, 
    Result<List<HotelEntity>, Error>>
{
    private readonly IHotelRepository _hotelRepository;

    public GetHotelsRequestHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<List<HotelEntity>, Error>> Handle(GetHotelsRequest request, 
        CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.GetAllAsync();

        return hotels;
    }
}
