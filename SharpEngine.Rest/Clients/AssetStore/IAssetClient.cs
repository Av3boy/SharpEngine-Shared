using SharpEngine.Shared.Dto.AssetStore;
using SharpEngine.Shared.Dto.Primitives;

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

    /// <summary>
    ///     Gets all assets created by the given user.
    /// </summary>
    /// <param name="userId">The id of the user whose assets should be retrieved.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>A collection of assets created by the specified user.</returns>
    Task<IEnumerable<AssetDto>> GetUserAssetsAsync(UserId userId, CancellationToken token = default);
}
