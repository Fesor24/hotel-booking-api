using HB.Domain.Models.HotelBed;
using HB.Domain.Models.Http;
using HB.Domain.Services.HotelBed;
using HB.Domain.Services.Http;
using HB.Domain.Shared;
using HB.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace HB.Infrastructure.Services.HotelBed;
public class HotelBedService : IHotelBedService
{
    private readonly IHttpClient _httpClient;
    private readonly HotelBedConfiguration _hotelBedConfig;

    public HotelBedService(IHttpClient httpClient, IOptions<HotelBedConfiguration> hotelBedConfig)
    {
        _httpClient = httpClient;
        _hotelBedConfig = hotelBedConfig.Value;
    }

    public async Task<Result<HotelBedStatusResponse, HotelBedErrorResponse>> CheckStatus()
    {
        string url = _hotelBedConfig.Url + "/hotel-api/1.0/status";

        var req = new HttpRequest();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Get;

        var res = await _httpClient.SendAsync<HotelBedStatusResponse, HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<HotelSearchResponse, HotelBedErrorResponse>> Search(HotelSearch search)
    {
        string url = _hotelBedConfig.Url + "/hotel-api/1.0/hotels";

        var req = new HttpRequest<HotelSearch>();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Post;
        req.Body = search;

        var res = await _httpClient.SendAsync<HotelSearch, HotelSearchResponse, HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<HotelRateResponse, HotelBedErrorResponse>> CheckRates(HotelRate rate)
    {
        string url = _hotelBedConfig.Url + "/hotel-api/1.0/checkrates";

        var req = new HttpRequest<HotelRate>();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Post;
        req.Body = rate;

        var res = await _httpClient.SendAsync<HotelRate, HotelRateResponse, HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<HotelsResponse, HotelBedErrorResponse>> GetHotels(int from, int to)
    {
        string url = _hotelBedConfig.Url + 
            $"/hotel-content-api/1.0/hotels?fields=all&language=ENG&from={from}&to={to}";

        var req = new HttpRequest();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Get;

        var res = await _httpClient.SendAsync<HotelsResponse, HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<HotelLocationResponse, HotelBedErrorResponse>> GetLocations(int from, int to)
    {
        string url = _hotelBedConfig.Url + 
            $"/hotel-content-api/1.0/locations/countries?fields=all&language=ENG&from={from}&to={to}";

        var req = new HttpRequest();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Get;

        var res = await _httpClient.SendAsync<HotelLocationResponse, HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<HotelBookingConfirmationResponse, HotelBedErrorResponse>> 
        ConfirmBooking(HotelBookingConfirmation confirmation)
    {
        string url = _hotelBedConfig.Url + "/hotel-api/1.0/bookings";

        var req = new HttpRequest<HotelBookingConfirmation>();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Post;
        req.Body = confirmation;

        var res = await _httpClient.SendAsync<HotelBookingConfirmation, HotelBookingConfirmationResponse, 
            HotelBedErrorResponse>(req);

        return res;
    }

    public async Task<Result<object, HotelBedErrorResponse>> GetFacilities(int from, int to)
    {
        string url = _hotelBedConfig.Url + $"/hotel-content-api/1.0/types/facilities?fields=all&from={from}&to{to}";

        var req = new HttpRequest();

        req = IncludeAuthHeaders(req);

        req.Uri = url;
        req.Method = HttpMethod.Get;

        var res = await _httpClient.SendAsync<object, HotelBedErrorResponse>(req);

        return res;
    }

    private string GetComputedHashedSignature()
    {
        string valueToBeHashed = _hotelBedConfig.ApiKey + _hotelBedConfig.Secret +
            DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(valueToBeHashed));

        StringBuilder sb = new();

        for(int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }

        return sb.ToString();
    }

    private HttpRequest IncludeAuthHeaders(HttpRequest req)
    {
        req.Headers.Add("Api-key", _hotelBedConfig.ApiKey);
        req.Headers.Add("X-Signature", GetComputedHashedSignature());

        return req;
    }

    private HttpRequest<TBody> IncludeAuthHeaders<TBody>(HttpRequest<TBody> req)
    {
        req.Headers.Add("Api-key", _hotelBedConfig.ApiKey);
        req.Headers.Add("X-Signature", GetComputedHashedSignature());

        return req;
    }
}
