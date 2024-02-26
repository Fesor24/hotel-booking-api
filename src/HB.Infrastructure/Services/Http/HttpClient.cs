using HB.Domain.Models.Http;
using HB.Domain.Services.Http;
using HB.Domain.Shared;
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

        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

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

        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<TResult>(jsonOptions);

            return res;
        }
        else
        {
            string errorMessage = response.ReasonPhrase;

            var err = await response.Content.ReadFromJsonAsync<TErrorResult>(jsonOptions);

            if(err is not null)
                err.Message = errorMessage;

            return err;
        }
    }

    public async Task<Result<TResult, TErrorResult>> SendAsync<TResult, TErrorResult>(HttpRequest model) 
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

        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<TResult>(jsonOptions);

            return res;
        }
        else
        {
            string errorMessage = response.ReasonPhrase;

            var err = await response.Content.ReadFromJsonAsync<TErrorResult>(jsonOptions);

            if (err is not null)
                err.Message = errorMessage;

            return err;
        }
    }
}
