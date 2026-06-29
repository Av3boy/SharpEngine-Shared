using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace SharpEngine.Rest.Clients;

/// <summary>
///     Represents a REST API client used to make HTTP calls.
/// </summary>
public abstract class RestClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    /// <summary>
    ///     Initializes a new instance of <see cref="RestClient" />.
    /// </summary>
    /// <param name="httpClient">A client used to make the HTTP calls.</param>
    /// <param name="logger">A logger used to write down executed actions.</param>
    public RestClient(HttpClient httpClient, ILogger<RestClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    ///     Adds headers to the given client.
    /// </summary>
    /// <returns>The calling context for chaining.</returns>
    public virtual RestClient WithHeaders() => this;

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP PUT method.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected result.</typeparam>
    /// <typeparam name="TBody">The type of the body contents.</typeparam>
    /// <param name="url">The url where the PUT resource should exist.</param>
    /// <param name="content">The content to be sent with the request.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the PUT operation.</returns>
    public async Task<TResult> PutAsync<TResult, TBody>(string url, TBody content, CancellationToken token = default)
    {
        var httpContent = await GetHttpContent(content, token);
        var response = await _httpClient.PutAsync(url, httpContent, token);

        response.EnsureSuccessStatusCode();

        return await DeserializeResultAsync<TResult>(response, token);
    }

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP DELETE method.
    /// </summary>
    /// <param name="url">The url where the DELETE resource should exist.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the DELETE operation.</returns>
    public async Task DeleteAsync(string url, CancellationToken token = default)
    {
        var response = await _httpClient.DeleteAsync(url, token);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP POST method.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected result.</typeparam>
    /// <typeparam name="TBody">The type of the body contents.</typeparam>
    /// <param name="url">The url where the POST resource should exist.</param>
    /// <param name="content">The content to be sent with the request.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the POST operation.</returns>
    public async Task<TResult> PostAsync<TResult, TBody>(string url, TBody content, CancellationToken token = default)
    {
        var httpContent = await GetHttpContent(content, token);

        var response = await _httpClient.PostAsync(url, httpContent, token);
        response.EnsureSuccessStatusCode();

        return await DeserializeResultAsync<TResult>(response, token);
    }

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP GET method.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected result.</typeparam>
    /// <param name="url">The url where the GET resource should exist.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the GET operation.</returns>
    public async Task<TResult> GetAsync<TResult>(string url, CancellationToken token = default)
    {
        var response = await _httpClient.GetAsync(url, token);
        response.EnsureSuccessStatusCode();

        return await DeserializeResultAsync<TResult>(response, token);
    }

    private static async Task<StreamContent> GetHttpContent<TBody>(TBody content, CancellationToken token)
    {
        var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, content, JsonSerializerOptions.Default, token);
        return new StreamContent(stream);
    }

    private static async Task<TResult> DeserializeResultAsync<TResult>(HttpResponseMessage response, CancellationToken token)
    {
        var jsonStream = await response.Content.ReadAsStreamAsync(token);

        var result = await JsonSerializer.DeserializeAsync<TResult>(jsonStream, JsonSerializerOptions.Default, token);
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
