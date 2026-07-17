using Microsoft.Extensions.Logging;
using SharpEngine.Rest.Clients.AssetStore;
using SharpEngine.Rest.Urls;
using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients.Portal;

/// <summary>
///     A client for interacting with the SharpEngine Users API.
/// </summary>
public class UserClient : RestClient, IUserClient
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserClient"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for making requests.</param>
    /// <param name="logger">The logger to use for logging.</param>
    public UserClient(HttpClient httpClient, ILogger<UserClient> logger)
        : base(httpClient, logger) { }

    /// <inheritdoc />
    public async Task<UserProfileDto?> GetUserDetailsAsync(UserId userId, CancellationToken token = default)
        => await GetAsync<UserProfileDto>(SharpEngine.Rest.Urls.Portal.GetUserById(userId), token);

    /// <inheritdoc />
    public async Task<UserProfileDto?> CreateUserAsync(UserProfileDto user, CancellationToken token = default)
        => await PostAsync<UserProfileDto>(SharpEngine.Rest.Urls.Portal.CreateUser, user, token);
}