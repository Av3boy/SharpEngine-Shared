using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients.Portal;

/// <summary>
///     Contains definitions for handling user achievements via REST API.
/// </summary>
internal interface IAchievementClient
{
    /// <summary>
    ///     Gets all the achievements the user has achieved.
    /// </summary>
    /// <param name="userId">The identifier of the user.</param>
    /// <param name="token">Propagates notification that operations should be canceled.</param>
    /// <returns>A collection of achievements the user has achieved.</returns>
    Task<IEnumerable<AchievementDto>> GetUserAchievementsAsync(UserId userId, CancellationToken token = default);
}