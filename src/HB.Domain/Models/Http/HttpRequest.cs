namespace HB.Domain.Models.Http;
public class HttpRequest
{
    public string Uri { get; set; }
    public HttpMethod Method { get; set; }
    public Dictionary<string, string> Headers { get; } = new();
}

public class HttpRequest<TBody> : HttpRequest
{
    public TBody Body { get; set; }
}
