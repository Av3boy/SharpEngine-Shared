using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SharpEngine.Rest.Clients;

namespace SharpEngine.Identity
{
    /// <summary>
    ///     Represents a client to handle Auth0 authorization and user authentication.
    /// </summary>
    /// <remarks>
    ///     <see href="https://auth0.com/docs/secure/tokens/access-tokens/get-access-tokens" />
    /// </remarks>
    public class Auth0Client : RestClient, IAuth0Client
    {
        private readonly ILogger<Auth0Client> _logger;

        /// <summary>
        ///     Initializes a new instance of <see cref="Auth0Client" />.
        /// </summary>
        /// <param name="logger">A logger used to write down executed operations.</param>
        /// <param name="client">An HTTP client used to make requests.</param>
        public Auth0Client(ILogger<Auth0Client> logger, HttpClient client) : base(client, logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<Auth0TokenResponseDto?> GetAccessTokenAsync(CancellationToken token = default)
        {
            // TODO: These env variables should be read properly from a configuration file or secret manager, not directly from environment variables.
            string domain = Environment.GetEnvironmentVariable("AUTH0_DOMAIN");
            string clientId = Environment.GetEnvironmentVariable("AUTH0_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("AUTH0_CLIENT_SECRET");

            // TODO: These should also be validated to ensure they are not null or empty.
            // Validatation attribute + DTO to hold these as attributes?
            if (string.IsNullOrWhiteSpace(clientId))
            {
                _logger.LogError("Missing required environment variable: AUTH0_CLIENT_ID.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                _logger.LogError("Missing required environment variable: AUTH0_CLIENT_SECRET.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(domain))
            {
                _logger.LogError("Missing required environment variable: AUTH0_DOMAIN.");
                return null;
            }

            string audience = $"https://{domain}/api/v2/";
            var tokenEndpoint = $"https://{domain}/oauth/token";

            var payload = new Auth0TokenRequestDto()
            {
                client_id = clientId,
                client_secret = clientSecret,
                audience = audience,
                grant_type = "client_credentials"
            };

            return await PostAsync<Auth0TokenResponseDto>(tokenEndpoint, payload, token);
        }
    }
}
