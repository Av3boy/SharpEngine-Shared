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

    internal static string GetUserById(UserId userId) => throw new NotImplementedException();

    /// <summary>
    ///     Gets the route to the api that retrievs all the achievements for an user.
    /// </summary>
    /// <param name="userid">The ID of the user whose achievements should be found.</param>
    /// <returns>The route to the api.</returns>
    public static string GetUserAchievements(UserId userId) => BaseUrl + $"achievements/{userId}";
}
