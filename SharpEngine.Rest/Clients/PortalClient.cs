using SharpEngine.Rest.Urls;
using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients;

public class PortalClient : RestClient, IPortalClient
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AssetStoreClient"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for making requests.</param>
    public PortalClient(HttpClient httpClient) : base(httpClient, Portal.BaseUrl) { }

    /// <inheritdoc />
    public async Task GetUserAchievements(UserId userId)
        => await GetAsync<AchievementDto>(Portal.GetUserAchievements(userId));


    /// <inheritdoc />
    public async Task<UserProfileDto> GetUserDetails(UserId userId)
        => await GetAsync<UserProfileDto>(Portal.GetUserById(userId));


    /// <inheritdoc />
    public async Task<UserProfileDto> CreateUser(UserProfileDto user)
        => await PostAsync<UserProfileDto>(Portal.CreateUser, user);

}
