using SharpEngine.Shared.Dto.AssetStore;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients;

/// <summary>
///     Represents a REST API client for interacting with the asset store API, providing methods to retrieve and manage assets.
/// </summary>
public class AssetStoreClient : RestClient, IAssetStoreClient
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AssetStoreClient"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for making requests.</param>
    public AssetStoreClient(HttpClient httpClient) : base(httpClient, Urls.AssetStore.BaseUrl) { }

    /// <inheritdoc />
    public async Task<AssetDto> GetAssetAsync(Guid assetId)
        => await GetAsync<AssetDto>(Urls.AssetStore.GetById(assetId));

    /// <inheritdoc />
    public async Task<IEnumerable<AssetDto>> GetUserAssetsAsync(UserId userId)
        => await GetAsync<IEnumerable<AssetDto>>(Urls.AssetStore.GetAllByAuthor(userId));
}
