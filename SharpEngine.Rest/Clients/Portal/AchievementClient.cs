using Microsoft.Extensions.Logging;
using SharpEngine.Rest.Urls;
using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;
using System.Net.Http;

namespace SharpEngine.Rest.Clients.Portal;

/// <summary>
///     Contains REST methods for handling user achievements.
/// </summary>
internal class AchievementClient : RestClient, IAchievementClient
{
    /// <summary>
    ///     Initializes a new instance of <see cref="AchievementClient" />
    /// </summary>
    /// <param name="httpClient">A http client used to make the REST API calls.</param>
    /// <param name="logger">A logger used to write down executed actions.</param>
    public AchievementClient(HttpClient httpClient, ILogger<AchievementClient> logger) 
        : base(httpClient, logger)
    {
        httpClient.BaseAddress = new Uri(Urls.AssetStore.BaseUrl);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AchievementDto>> GetUserAchievementsAsync(UserId userId, CancellationToken token = default)
        => await GetAsync<IEnumerable<AchievementDto>>(Urls.Portal.GetUserAchievements(userId), token);
}
