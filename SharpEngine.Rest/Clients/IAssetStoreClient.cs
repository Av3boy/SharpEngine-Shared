using SharpEngine.Shared.Dto.AssetStore;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients;

/// <summary>
///     Contains definitions for the asset store API client, which provides methods to interact with the asset store REST API.
/// </summary>
public interface IAssetStoreClient
{
    /// <summary>
    ///     Gets an asset by its unique identifier from the asset store API.
    /// </summary>
    /// <param name="assetId">The unique identifier of the asset to retrieve.</param>
    /// <returns>
    ///     A <see cref="Task"/> representing the asynchronous operation. 
    ///     The result contains the found asset.
    /// </returns>
    Task<AssetDto> GetAssetAsync(Guid assetId);
    Task<IEnumerable<AssetDto>> GetUserAssetsAsync(UserId userId);
}
