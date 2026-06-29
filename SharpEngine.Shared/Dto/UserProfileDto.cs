using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Shared.Dto;

/// <summary>
///     Represents a user profile in the SharpEngine system.
/// </summary>
public class UserProfileDto
{
    /// <summary>
    ///     Gets or initializes the unique identifier for the user profile.
    /// </summary>
    /// <remarks>
    ///     This is assigned by the database when the user profile is created.
    /// </remarks>
    public UserId? UserId { get; init; }

    /// <summary>
    ///     Gets or initializes the username of the user.
    /// </summary>
    public string Username { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the email address of the user.
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    ///     Gets or initializes the unique identifier from Auth0 for the user.
    /// </summary>
    public string Auth0Identifier { get; init; } = string.Empty;

    // TODO: What user details do we need from Auth0?

    /// <summary>
    ///     Gets or initializes the social media links associated with the user.
    /// </summary>
    public SocialMediaDto LinkedSocialMedia { get; init; } = new();

    /// <summary>
    ///     Gets or initializes the list of projects created by the user.
    /// </summary>
    public IEnumerable<ProjectDto> Projects { get; init; } = [];

    /// <summary>
    ///     Gets or initializes the list of achievements unlocked by the user.
    /// </summary>
    public IEnumerable<AchievementDto> Achievements { get; init; } = [];

    /// <summary>
    ///     Gets or initializes the user settings for the user profile.
    /// </summary>
    public UserSettingsDto Settings { get; init; } = new();

    /// <summary>
    ///     Gets or initializes the date and time when the user first logged in to the SharpEngine system.
    /// </summary>
    public DateTime FirstLogin { get; init; }
}

/// <summary>
///     Represents the user settings for a user profile in the SharpEngine system.
/// </summary>
public class UserSettingsDto
{
}