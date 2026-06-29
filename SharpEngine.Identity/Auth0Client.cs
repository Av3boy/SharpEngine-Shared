using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace SharpEngine.Identity;

public interface IAuth0Client
{
    Task<string?> GetAccessToken();
}

/// <summary>
///     Represents a client to handle Auth0 authorization and user authentication.
/// </summary>
public class Auth0Client : IAuth0Client
{
    private readonly ILogger<Auth0Client> _logger;
    
    /// <summary>
    ///     Initializes a new instance of <see cref="Auth0Client" />.
    /// </summary>
    /// <param name="logger">A logger used to write down executed operations.</param>
    public Auth0Client(ILogger<Auth0Client> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<string?> GetAccessToken()
    {
        string domain = Environment.GetEnvironmentVariable("AUTH0_DOMAIN");
        string clientId = Environment.GetEnvironmentVariable("AUTH0_CLIENT_ID");
        string clientSecret = Environment.GetEnvironmentVariable("AUTH0_CLIENT_SECRET");

        if (string.IsNullOrWhiteSpace(clientId))
        {
            Console.Error.WriteLine("Missing required environment variable: AUTH0_CLIENT_ID.");
            return null;
        }

        if (string.IsNullOrWhiteSpace(clientSecret))
        {
            Console.Error.WriteLine("Missing required environment variable: AUTH0_CLIENT_SECRET.");
            return null;
        }

        if (string.IsNullOrWhiteSpace(domain))
        {
            Console.Error.WriteLine("Missing required environment variable: AUTH0_DOMAIN.");
            return null;
        }

        string audience = $"https://{domain}/api/v2/";
        var tokenEndpoint = $"https://{domain}/oauth/token";

        using var httpClient = new HttpClient();
        var payload = new
        {
            client_id = clientId,
            client_secret = clientSecret,
            audience = audience,
            grant_type = "client_credentials"
        };

        var json = JsonSerializer.Serialize(payload);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response;
        try
        {
            response = await httpClient.PostAsync(tokenEndpoint, content).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
            return null;
        }

        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            Console.Error.WriteLine($"Token request failed ({(int)response.StatusCode}): {responseText}");
            return null;
        }

        try
        {
            using var doc = JsonDocument.Parse(responseText);
            if (doc.RootElement.TryGetProperty("access_token", out var accessToken))
            {
                Console.WriteLine("Access token acquired.");
                return accessToken.GetString();
            }

            Console.Error.WriteLine("Token response did not contain an access_token.");
            return null;
        }
        catch (JsonException)
        {
            Console.Error.WriteLine("Failed to parse token response JSON.");
            return null;
        }
    }
}
