using HB.Domain.Entity.HotelAggregate;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders;

namespace HB.Application.Features.Hotel.Commands.Create;
internal sealed class CreateHotelsCommandHandler : IRequestHandler<CreateHotelsCommand, Result<bool, Error>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IHotelBedService _hotelBedService;

    public CreateHotelsCommandHandler(IHotelRepository hotelRepository, IHotelBedService hotelBedService)
    {
        _hotelRepository = hotelRepository;
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<bool, Error>> Handle(CreateHotelsCommand request, CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetHotels(request.From, request.To);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorDetails);
        }

        List<HotelEntity> hotels = new();

        foreach(var item in res.Value.Hotels)
        {
            if (item is null)
                continue;

            List<HotelEntity.PhoneContact> contacts = new();

            foreach(var contact in item.Phones)
            {
                HotelEntity.PhoneContact cont = new()
                {
                    PhoneNumber = contact.PhoneNumber,
                    PhoneType = contact.PhoneType
                };

                contacts.Add(cont);
            }

            HotelEntity hotel = new()
            {
                Name = item.Name.Content,
                Description = item.Description.Content,
                Address = item.Address.Content,
                City = item.City.Content,
                Code = item.Code,
                Contact = contacts,
                CountryCode = item.CountryCode,
                DestinationCode = item.DestinationCode,
                PostalCode = item.PostalCode,
                Email = item.Email,
                Images = item.Images.Select(x => x.Path).ToList(),
                License = item.License,
                Ranking = item.Ranking,
                StateCode = item.StateCode
            };

            hotels.Add(hotel);
        }

        await _hotelRepository.AddRangeAsync(hotels);

        return true;
    }
}
