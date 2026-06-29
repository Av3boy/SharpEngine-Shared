using SharpEngine.Shared.Dto.AssetStore;

namespace SharpEngine.Rest.Clients.AssetStore;

/// <summary>
///     Contains definitions for handling asset store assets.
/// </summary>
public interface IAssetClient
{
    /// <summary>
    ///     Gets an asset with the given asset id.
    /// </summary>
    /// <param name="assetId">The id of the asset to be found.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>The asset if found; otherwise, <see langword="null" />.</returns>
    Task<AssetDto?> GetAssetAsync(Guid assetId, CancellationToken token = default);
}
