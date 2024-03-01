using HB.Domain.Models.Http;
using HB.Domain.Services.Http;
using HB.Domain.Shared;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace HB.Infrastructure.Services.Http;
public class HttpClient : IHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Result<TResult, TErrorResult>> SendAsync<TBody, TResult, TErrorResult>
        (HttpRequest<TBody> model) where TErrorResult : BaseError
    {
        using var client = _httpClientFactory.CreateClient();

        HttpResponseMessage response = new();

        foreach(var header in model.Headers)
        {
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        try
        {
            response = await client.SendAsync(new HttpRequestMessage
            {
                Method = model.Method,
                RequestUri = new Uri(model.Uri),
                Content = JsonContent.Create(model.Body)
            });
        }
        catch (Exception ex)
        {
            throw;
        }

        return await HandleResponse<TResult, TErrorResult>(response);
    }

    public async Task<Result<TResult, TErrorResult>> SendAsync<TResult, TErrorResult>
        (Domain.Models.Http.HttpRequest model) 
        where TErrorResult : BaseError
    {
        using var client = _httpClientFactory.CreateClient();

        HttpResponseMessage response = new();

        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        foreach (var header in model.Headers)
        {
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        try
        {
            response = await client.SendAsync(new HttpRequestMessage
            {
                Method = model.Method,
                RequestUri = new Uri(model.Uri)
            });
        }
        catch (Exception ex)
        {
            throw;
        }

        return await HandleResponse<TResult, TErrorResult>(response);
    }

    private async Task<Result<TResult, TErrorResult>> HandleResponse<TResult, TErrorResult>(HttpResponseMessage response)
        where TErrorResult : BaseError
    {
        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<TResult>(jsonOptions);

            return res;
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
           response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            string errorMessage = response.ReasonPhrase;

            var err = await response.Content.ReadFromJsonAsync<TErrorResult>(jsonOptions);

            if (err is not null)
                err.Message = errorMessage;

            return err;
        }
        else
        {
            TErrorResult err = (TErrorResult)Activator.CreateInstance(typeof(TErrorResult));

            var error = await response.Content.ReadAsStringAsync();

            err.Message = response.ReasonPhrase;

            err.Details = error;

            return err;
        }
    }
}
