using Microsoft.Extensions.Logging;
using SharpEngine.Rest.Clients;
using SharpEngine.Rest.Urls;
using SharpEngine.Shared.Dto.AssetStore;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients.AssetStore;

/// <summary>
///     Represents a REST API client for handling Asset Store assets.
/// </summary>
public class AssetClient : RestClient, IAssetClient
{
    /// <summary>
    ///     Initializes a new instance of <see cref="AssetClient" />.
    /// </summary>
    /// <param name="httpClient">A client used to send the REST API calls.</param>
    /// <param name="logger">A logger used to write down the executed actions.</param>
    public AssetClient(HttpClient httpClient, ILogger<AssetClient> logger) 
        : base(httpClient, logger) { }

    /// <inheritdoc />
    public async Task<AssetDto?> GetAssetAsync(Guid assetId, CancellationToken token = default)
        => await GetAsync<AssetDto?>(Urls.AssetStore.GetById(assetId), token);

    /// <inheritdoc />
    public async Task<IEnumerable<AssetDto>> GetUserAssetsAsync(UserId userId, CancellationToken token = default)
        => await GetAsync<IEnumerable<AssetDto>>(Urls.AssetStore.GetAllByAuthor(userId), token);
}
