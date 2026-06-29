using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Urls;

/// <summary>
///     Contains REST API endpoint URLs for the portal.
/// </summary>
public static class Portal
{
    /// <summary>
    ///     Gets the base URL for the portal API
    /// </summary>
    public const string BaseUrl = "https://portal.sharpengine.com/";
    public const string CreateUser = $"{BaseUrl}users";

    internal static string GetUserAchievements(UserId userId) => throw new NotImplementedException();
    internal static string GetUserById(UserId userId) => throw new NotImplementedException();
}
