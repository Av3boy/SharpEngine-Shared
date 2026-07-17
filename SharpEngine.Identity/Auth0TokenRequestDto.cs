namespace SharpEngine.Identity;

public class Auth0TokenRequestDto
{
    // Set this to “client_credentials”.
    public required string grant_type { get; init; }

    // Your application’s Client ID.You can find this value on the application’s settings tab.
    public required string client_id { get; init; }

    // Your application’s Client Secret.You can find this value on the application’s settings tab.To learn more about available application authentication methods, read Application Credentials.
    public required string client_secret { get; init; }

    // The audience for the token, which is your API.You can find this in the Identifier field on your API’s settings tab.
    public required string audience { get; init; }

    // Optional. The organization name or identifier you want the request to be associated with.To learn more, read Machine-to-Machine Access for Organizations.
    public string? organization { get; set; } = null;
}