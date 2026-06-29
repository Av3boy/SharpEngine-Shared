using SharpEngine.Rest.Urls;
using System.Diagnostics;
using System.Text.Json;

namespace SharpEngine.Rest.Clients;

/// <summary>
///     Represents a base REST API client that provides common functionality for making HTTP requests and handling responses, which can be extended by specific API clients like <see cref="AssetStoreClient"/> to interact with different endpoints of the asset store API.
/// </summary>
public abstract class RestClient
{
    private readonly HttpClient _httpClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RestClient"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for making requests.</param>
    /// <param name="baseUrl">The base URL for the API.</param>
    public RestClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    /// <summary>
    ///     Makes a GET request to the specified URL and deserializes the response into the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type into which the response should be deserialized.</typeparam>
    /// <param name="url">The URL to request.</param>
    /// <returns>
    ///     A <see cref="Task{T}"/> representing the asynchronous operation.
    ///     The result contains the deserialized object.
    /// </returns>
    protected async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(json);
        Debug.Assert(result is not null, "Deserialized result is null.");

        return result;
    }

    protected async Task<T> PostAsync<T>(string url, object body)
    {
        var jsonBody = JsonSerializer.Serialize(body);
        var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);
        
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<T>(json);
        Debug.Assert(result is not null, "Deserialized result is null.");
        
        return result;
    }
}
