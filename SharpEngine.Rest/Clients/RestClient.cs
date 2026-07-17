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
    /// <returns>The results of the PUT operation; <see langword="null"/> if an error occurred.</returns>
    public async Task<TResult?> PutAsync<TResult, TBody>(string url, TBody content, CancellationToken token = default)
    {
        try
        {
            var httpContent = await GetHttpContent(content, token);
            var response = await _httpClient.PutAsync(url, httpContent, token);

            response.EnsureSuccessStatusCode();

            return await DeserializeResultAsync<TResult>(response, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while making a PUT request to {Url}", url);
            return default;
        }
    }

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP DELETE method.
    /// </summary>
    /// <param name="url">The url where the DELETE resource should exist.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the DELETE operation.</returns>
    public async Task DeleteAsync(string url, CancellationToken token = default)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(url, token);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while making a DELETE request to {Url}", url);
        }
    }

    /// <summary>
    ///     Makes an REST API call to the given <paramref name="url"/> address with the HTTP POST method.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected result.</typeparam>
    /// <param name="url">The url where the POST resource should exist.</param>
    /// <param name="content">The content to be sent with the request.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The results of the POST operation; <see langword="null"/> if an error occurred.</returns>
    public async Task<TResult?> PostAsync<TResult>(string url, object content, CancellationToken token = default)
    {
        try
        {
            var httpContent = await GetHttpContent(content, token);

            var response = await _httpClient.PostAsync(url, httpContent, token);
            response.EnsureSuccessStatusCode();

            return await DeserializeResultAsync<TResult>(response, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while making a POST request to {Url}", url);
            return default;
        }
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
        try
        {
            var response = await _httpClient.GetAsync(url, token);
            response.EnsureSuccessStatusCode();

            return await DeserializeResultAsync<TResult>(response, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while making a GET request to {Url}", url);
            return default!;
        }
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
}
