using System.Net.Http;
using System.Text;
using System.Text.Json;
using RestfulBookerApiFramework.Config;

namespace RestfulBookerApiFramework.Base;

public class ApiClient
{
    private readonly HttpClient _client;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };
    public ApiClient()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(
                SettingsManager.Settings.Application.BaseUrl)
        };

        // Tells the API that we expect JSON responses.
        _client.DefaultRequestHeaders.Add(
            "Accept",
            "application/json");
    }
    public async Task<T> GetAsync<T>(string endpoint)
    {
        // Build the GET request.
        var request = BuildRequest<object>(
            HttpMethod.Get,
            endpoint
        );

        // Send the request and deserialize the response.
        return await SendAsync<T>(request);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest body,
        Dictionary<string, string>? headers = null)
    {
        // Build the POST request.
        var request = BuildRequest(
            HttpMethod.Post,
            endpoint,
            body,
            headers);

        // Send the request and deserialize the response.
        return await SendAsync<TResponse>(request);
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(
        string endpoint,
        TRequest body,
        Dictionary<string, string>? headers = null)
    {
        // Build the PUT request.
        var request = BuildRequest(
            HttpMethod.Put,
            endpoint,
            body,
            headers);

        // Send the request and deserialize the response.
        return await SendAsync<TResponse>(request);
    }

    public async Task<TResponse> PatchAsync<TRequest, TResponse>(
        string endpoint,
        TRequest body,
        Dictionary<string, string>? headers = null)
    {
        // Build the PATCH request.
        var request = BuildRequest(
            HttpMethod.Patch,
            endpoint,
            body,
            headers
        );

        // Send the request and deserialize the response.
        return await SendAsync<TResponse>(request);
    }
    private HttpRequestMessage BuildRequest<T>(
        HttpMethod method,
        string endpoint,
        T? body = default,
        Dictionary<string, string>? headers = null)
    {
        // Create the HTTP request using the supplied
        // HTTP method and endpoint.
        var request = new HttpRequestMessage(
            method,
            endpoint);

        // Add any headers supplied by the service.
        // This is where authentication information,
        // such as the token cookie, can be added.
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(
                    header.Key,
                    header.Value);
            }
        }

        // If a request body was supplied, serialize the
        // C# object into JSON and attach it to the request.
        if (body is not null)
        {
            var json = JsonSerializer.Serialize(
                body,
                JsonOptions);

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");
        }

        return request;
    }

    private async Task<T> SendAsync<T>(
        HttpRequestMessage request)
    {
        // Send the HTTP request to the API.
        var response = await _client.SendAsync(request);

        // Throws an exception if the API returns an unsuccessful
        // HTTP status code such as 400, 401, 404 or 500.
        response.EnsureSuccessStatusCode();

        // Read the response body as a JSON string.
        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"API Response: {json}");

        // Deserialize the JSON response into our C# model.
        return JsonSerializer.Deserialize<T>(
            json,
            JsonOptions)!;
    }

    public async Task<HttpResponseMessage> GetResponseAsync(
        string endpoint)
    {
        return await _client.GetAsync(endpoint);
    }

    public async Task DeleteAsync(
        string endpoint,
        Dictionary<string, string>? headers)
    {
        // Build the DELETE request.
        var request = BuildRequest<object>(
            HttpMethod.Delete,
            endpoint,
            headers: headers
        );

        // Send the DELETE request.
        var response = await _client.SendAsync(request);

        // Throws an exception if the API does not return
        // a successful status code.
        response.EnsureSuccessStatusCode();
    }

    public async Task<HttpResponseMessage> SendRequestAsync<T>(
        HttpMethod method,
        string endpoint,
        T? body = default,
        Dictionary<string, string>? headers = null
    )
    {
        var request = BuildRequest<T>(
            method,
            endpoint,
            body,
            headers: headers
        );

        return await _client.SendAsync(request);
    }
}